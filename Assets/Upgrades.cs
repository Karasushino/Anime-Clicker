﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;



public class Upgrades : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Number of Significant Figures rounded on UI")]
    private int significant_figure = 2;

    //All main Score Variables and their multipliers

    //Keep track of Levels of Upgrades
    //Headpat Level (Upgrade)
    private static int headPat_level = 1;
    [SerializeField]
    //AutoClicker Level (Upgrade)
    private int AutoClick_level = 1;
    [SerializeField]
    [Tooltip("The amount that points are going to increase exponentially")]
    private const float headPat_level_exponential = 4f;
    [SerializeField]
    [Tooltip("The amount of time that needs to pass before auto clicking in s")]
    private  float autoClick_timer = 1.0f;
    private  float startTimer = 0f;


    //Costs to upgrade to next level
    [SerializeField]
    private float headPat_cost;
    [SerializeField]
    private float autoClicker_cost;

    //The percentage increased on the cost of the upgrades
    [SerializeField]
    [Tooltip("Multiplier of Increase  (Cost + Cost*multiplier)")]
    private float headPat_cost_multiplier = 1.2f;
    [SerializeField]
    [Tooltip("Multiplier of Increase(Cost + Cost * multiplier)")]
    private float autoClicker_cost_multiplier = 0.8f;

    public enum Upgrade
    {
        HEADPAT,
        AUTOCLICKER

    }

    public TextMeshProUGUI UpgradeTitle;
    public TextMeshProUGUI UpgradeDescription;
    public TextMeshProUGUI Level;
    public TextMeshProUGUI Cost;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch (UpgradeSelectedState.SelectedUpgrade)
        {
            case Upgrade.HEADPAT:
                displayHeadpatUpgrade();
                break;
            case Upgrade.AUTOCLICKER:
                displayAutoClickerUpgrade();
                break;
        }

        //Passive Auto Click (Have to implement it based on level, that will go into upgrade function
        //For now this adds the points after x time elapsed. Upgrade just lowers autoclick timer)
        addAutoClick();
        

    }
    //GAME LOGIC FUNCTIONS
    public void upgradeHeadpat()
    {
        //If enough waifu points upgrade and remove cost from total waifu points
        if (ClickerCounter.waifuPoints >= headPat_cost)
        {
            //Remove waifu points
            ClickerCounter.waifuPoints -= headPat_cost;
            //Increase Level
            headPat_level++;

            //Now increase cost for the next time
            //Add x Percent to the cost of the upgrade
            float addToCost = headPat_cost * headPat_cost_multiplier;
            Debug.Log("Headpat multiplier: " + headPat_cost_multiplier);
            Debug.Log("Cost To Add to Headpat: " + addToCost);
            Debug.Log("Headpat cost Before adding: " + headPat_cost);
            headPat_cost += Mathf.Round(addToCost);

            //Update new values
            DisplayFormatedValueText(headPat_level, Level, significant_figure);

            //Reformat Cost Display
            DisplayFormatedValueText((int)headPat_cost, Cost, significant_figure);

        }
    }

    public void addAutoClick()
    {
        //Store initial time once
        
            
        //Basic Countdown Code
        if (startTimer < autoClick_timer)
        {

            //Decrese time elapsed between frames to countdown every frame
            startTimer += Time.deltaTime;
            Debug.Log("Current Timer: " + startTimer);
        }
        else
        {
            startTimer = 0;
            //Time has passed add the points
            ClickerCounter.numberOfClicks++;
            ClickerCounter.totalClicks++;
            ClickerCounter.SpawnParticle();
            //Reset timer variable to save it next frame
            Debug.Log("Timer Reset to: " + autoClick_timer);
            
        }
    }


    public static void addWaifuPoints()
    {
        //Adds waifu Points based on the level
        //Exponential increase because price is exponentially increased too, for balance purposes
        //Just change the exponential value to get ponints faster or slower
        float pointsToAdd = 1f * (Mathf.Pow((float)headPat_level, headPat_level_exponential));
        Debug.Log("Points Added:" + pointsToAdd);
        ClickerCounter.waifuPoints += pointsToAdd;
    }

    //UI DISPLAY FUNCTIONS
    public void displayHeadpatUpgrade()
    {
        UpgradeTitle.text = "Better Headpats";
        UpgradeDescription.text = "Headpats = waifu points";

        Level.text = headPat_level.ToString();
        DisplayFormatedValueText(headPat_cost, Cost, significant_figure);
    }
    public void displayAutoClickerUpgrade()
    {
        UpgradeTitle.text = "Auto Clicker";
        UpgradeDescription.text = "Free Clicks = MORE waifu points";
        Level.text = headPat_level.ToString();
        Cost.text = headPat_cost.ToString();
    }

    
    //Utility helpers


    static float Round(float value, int digits)
    {
        float mult = Mathf.Pow(10.0f, (float)digits);
        return Mathf.Round(value * mult) / mult;
    }

    //Display Score Rounded
    public static void DisplayFormatedValueText(float score, TextMeshProUGUI DisplayText, int digits)
    {

        

        //If over a Million change to M

        if (score >= 1000000)
        {

            float PointsDisplay = ((float)score / 1000000f);
            PointsDisplay = Round(PointsDisplay, digits);

            DisplayText.text = PointsDisplay.ToString() + " M";
        }
        else
        {
            DisplayText.text = score.ToString();
        }


    }

    
}

