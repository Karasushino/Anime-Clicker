using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using BayatGames.SaveGameFree;


public class Waifu_Selector : MonoBehaviour
{

    //Create Array, set size in Editor
    //MUST BE EQUAL TO NUMBER_OF_WAIFUS
    [SerializeField]
    [Tooltip("Set the number of waifus in the game and assign them a cost")]
    private long[] Waifu_cost_array;

    //Drag SpriteRenderer from Editor
    [SerializeField]
    [Tooltip("The Sprite to Display")]
    private SpriteRenderer Waifu_spriteRenderer;

    [SerializeField]
    [Tooltip("The Sprite to Display")]
    private SpriteRenderer Waifu_INGAME;


    //Sets the number of waifus that there is in the game
    //IMPORTANT TO CHANGE THIS WHENEVER A WAIFU IS ADDED
    //CAN'T THINK OF ANOTHER SYSTEM RIGHT NOW (Without editor drag and drop, and I want to load from resources)
    //ALSO NEEDS TO CHANGE IN THE EDITOR!!!
    const int number_of_waifus = 11;

    //Variable that will keep track of current selected waifu
    [SerializeField]
    private int current_waifu = 0;
    //Variable that stores selected waifu
    [SerializeField]
    private int selected_waifu = 0;


    //Get Unlock for Text and Unlock cost Text
    public TextMeshProUGUI text_unlock_for_tag;
    public TextMeshProUGUI text_unlock_cost;

    //Text in Button for the Waifu Select Menu (Upgrade button)
    [SerializeField] private TextMeshProUGUI upgradeButton_text;

    //Set number of significant figures default to 2
    public int singificant_figures = 2;



    //Struct containing relevent waifu data (Loading to a list all this data 
    //so it can be swapped on demand later on) Easily Extended if ever want to add names, etc.
    struct Waifu_data
    {
        public Sprite sprite;
        public long cost;
        public bool isUnlocked;
    }

    //To save if it was unlocked
    static bool[] isUnlockedSave = new bool[number_of_waifus];
    //To save selected waifu
    static int SelectedWaifuSave;


    Waifu_data[] Waifu_list = new Waifu_data[number_of_waifus];



    // Start is called before the first frame update

    void Awake()
    {
        //LOADS WAIFU DATA AND ADDS TO A LIST WHERE ALL WAIFU DATA IS STORED
        //Temporal Variables

       

        Load();


    }


    // Update is called once per frame
    void Update()
    {
        Save();

        //Gets current Waifu selected
        Waifu_data currentWaifu = Waifu_list[current_waifu];
        Waifu_data selectedWaifu = Waifu_list[selected_waifu];

        //UI Updates 
        changeButtonText();
        //Display cost of selected waifu in Waifu Menu
        Upgrades.DisplayFormatedValueText(currentWaifu.cost, text_unlock_cost, singificant_figures);



        //Render Sprite
        //Changes current Waifu sprite from the Waifu List
        Waifu_spriteRenderer.sprite = currentWaifu.sprite;
        Debug.Log("Cost of waifu: " + currentWaifu.cost);
        //Changes selected waifu in the game
        Waifu_INGAME.sprite = selectedWaifu.sprite;



    }

    public void moveToNextWaifu()
    {
        if (current_waifu < number_of_waifus - 1)
        {
            //Reset to previous one
            current_waifu++;
        }
        else
        {
            current_waifu = 0;
        }
    }

    public void moveToPreviousWaifu()
    {
        if (current_waifu > 0)
        {
            //Reset to next one
            current_waifu--;
        }
        else
        {
            current_waifu = number_of_waifus - 1;
        }
    }




    public void waifuMenuUnlockButton()
    {

        //Type less (It's a copy)
        Waifu_data waifu = Waifu_list[current_waifu];
        //Just unlocks it and allows to see Select text
        //This changes behavour from unlock to Select (not implemented)
        //If it isn't unlocked and the number of points is bigger or equal to the cost
        if (!waifu.isUnlocked)
        {
            if (ClickerCounter.waifuPoints >= waifu.cost)
            {
                //Take Points away
                ClickerCounter.waifuPoints -= waifu.cost;

                //Change boolean to unlocked (from the data in the list, not the copy)
                Waifu_list[current_waifu].isUnlocked = true;
            }

        }
        //else it means its unlocked and should select it
        else
        {
            //Save index of current waifu as selected
            selected_waifu = current_waifu;

        }



    }

    //Intended to run every frame 
    private void changeButtonText()
    {
        //Type less
        Waifu_data waifu = Waifu_list[current_waifu];

        if (!waifu.isUnlocked)
        {
            upgradeButton_text.text = "Unlock";

        }
        else
        {
            upgradeButton_text.text = "Select";
            if (selected_waifu == current_waifu)
                upgradeButton_text.text = "Selected";
        }

    }


    void Save()
    {
        for (int a = 0; a < Waifu_list.Length; a++)
        {
            isUnlockedSave[a] = Waifu_list[a].isUnlocked;
        }

        SaveGame.Save<bool[]>("Save Waifu", isUnlockedSave);
        SaveGame.Save<int>("Selected Waifu", selected_waifu);
    }

    void Load()
    {
        Waifu_data temporal_data;
        //Uses cost array lenght to loop through all waifus

        for (int i = 0; i < number_of_waifus; i++)
        {
            //Load Texture
            temporal_data.sprite = Resources.Load<Sprite>("Waifus/Waifu " + i);
            //Set Cost
            temporal_data.cost = Waifu_cost_array[i];
            //Set default to non unlocked
            temporal_data.isUnlocked = false;
            Waifu_list[i] = temporal_data;
            //Init with dummy
            isUnlockedSave[i] = false;

        }


        //Comment all this before build

        //isUnlockedSave[0] = true;

        //isUnlockedSave = SaveGame.Load<bool[]>("Save Waifu", isUnlockedSave);

        //for (int a = 0; a < Waifu_list.Length; a++)
        //{
        //    Waifu_list[a].isUnlocked = isUnlockedSave[a];
        //}

        //selected_waifu = SaveGame.Load<int>("Selected Waifu", selected_waifu);

    }

    
}
