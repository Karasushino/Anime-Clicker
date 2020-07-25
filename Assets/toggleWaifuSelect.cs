using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class toggleWaifuSelect : MonoBehaviour
{
    public static bool isActive = false;
    //Get the canvas and sprites
    public GameObject[] Objects;


    //Get Waifu Points Text
    public TextMeshProUGUI WaifuScore;

   

    //Formating Values
    public int Significant_figures;


    private void Update()
    {
       //Display current ammount of points in Waifu Menu
        Upgrades.DisplayFormatedValueText(ClickerCounter.waifuPoints, WaifuScore, Significant_figures);
       


    }

    public void toggleUIWaifuON()
    {
        //If it isn't active, activate all the UI elements needed
        if (!isActive)
        {
            foreach(GameObject a in Objects)
            {
                a.SetActive(true);
            }
            isActive = true;

            //Deactivate Click Detection
            toggleClickDetection.isClickingDetection = false;
        }
        else
        {
            Debug.Log("Somehow tried to toggle Waifu UI off when it was already OFF");
        }
    }

    //Goes back to main game
    public void toggleUIWaifuOFF()
    {
        //If it is active, deactivate all the UI elements needed
        if (isActive)
        {
            foreach (GameObject a in Objects)
            {
                a.SetActive(false);
                isActive = false;

                //Reactivate Click Detection
                toggleClickDetection.isClickingDetection = true;
            }
        }
        else
        {
            Debug.Log("Somehow tried to toggle Waifu UI on when it was already ON");
        }
    }
}
