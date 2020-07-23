using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Waifu_Selector : MonoBehaviour
{

    //Create Array, set size in Editor
    [SerializeField]
    [Tooltip("Set the number of waifus in the game and assign them a cost")]
    private int[] Waifu_cost_array;

    //Drag SpriteRenderer from Editor
    [SerializeField]
    [Tooltip("The Sprite to Display")]
    private SpriteRenderer Waifu_spriteRenderer;


    //Sets the number of waifus that there is in the game
    //IMPORTANT TO CHANGE THIS WHENEVER A WAIFU IS ADDED
    //CAN'T THINK OF ANOTHER SYSTEM RIGHT NOW
    const int number_of_waifus = 2;

    //Variable that will keep track of current selected waifu
    [SerializeField] private int current_waifu = 0;

    //Get Unlock for Text and Unlock cost Text
    public TextMeshProUGUI text_unlock_for_tag;
    public TextMeshProUGUI text_unlock_cost;
    //Set number of significant figures default to 2
    public int singificant_figures = 2;
    


    //Struct containing relevent waifu data (Loading to a list all this data 
    //so it can be swapped on demand later on) Easily Extended if ever want to add names, etc.
    struct Waifu_data
    {
        public Sprite sprite;
        public int cost;
        public bool isUnlocked;
    }


    private Waifu_data[] Waifu_list = new Waifu_data[2];

    // Start is called before the first frame update
    void Start()
    {
        //LOADS WAIFU DATA AND ADDS TO A LIST WHERE ALL WAIFU DATA IS STORED
        //Temporal Variables

        Waifu_data temporal_data;
        //Uses cost array lenght to loop through all waifus
        for (int i = 0; i < Waifu_cost_array.Length; i++)
        {
            //Load Texture
            temporal_data.sprite = Resources.Load<Sprite>("Waifus/Waifu " + i);
            //Set Cost
            temporal_data.cost = Waifu_cost_array[i];
            //Set default to non unlocked
            temporal_data.isUnlocked = false;
            Waifu_list[i] = temporal_data;
        }

    }


    // Update is called once per frame
    void Update()
    {
        //Debug stuff to see if it works
        //Debug.Log("Cost of Waifu: " + Waifu_list[1].cost);

        //Gets current Waifu selected
        Waifu_data currentWaifu = Waifu_list[current_waifu];

        //Display cost of selected waifu in Waifu Menu
        Upgrades.DisplayFormatedValueText(currentWaifu.cost,text_unlock_cost,singificant_figures);



        //Changes to selected Waifu sprite from the Waifu List
        Waifu_spriteRenderer.sprite = currentWaifu.sprite;


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
}
