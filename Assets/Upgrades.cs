using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;



public class Upgrades : MonoBehaviour
{



    //Acts as a multiplyer of waifu 
    //Keep track of Levels of Upgrades
    [SerializeField]
    private static int headPat_level = 10;
    [SerializeField]
    [Tooltip("Between 1 and 2 recommended")]
    [Range(1f, 2f)]
    private const float headPat_level_exponential = 4f;
    [SerializeField]
    private static int autoClicker_level = 1;
    //Costs to upgrade to next level
    [SerializeField]
    private int headPat_cost;
    [SerializeField]
    private int autoClicker_cost;
    //The percentage increased on the cost of the upgrades
    [SerializeField]
    [Tooltip("In percentage value")]

    private int headPat_cost_multiplier = 20;
    [SerializeField]
    [Tooltip("In percentage value")]
    private int autoClicker_cost_multiplier = 20;

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



    }

    public void displayHeadpatUpgrade()
    {


        UpgradeTitle.text = "Better Headpats";
        UpgradeDescription.text = "Headpats = waifu points";

        Level.text = headPat_level.ToString();
        DisplayFormatedValueText(headPat_cost, Cost);
    }
    public void displayAutoClickerUpgrade()
    {
        UpgradeTitle.text = "test";
        UpgradeDescription.text = "test = waifu points";
        Level.text = headPat_level.ToString();
        Cost.text = headPat_cost.ToString();
    }

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
            headPat_cost += (headPat_cost * headPat_cost_multiplier) / 100;

            //Update new values
            DisplayFormatedValueText(headPat_level, Level);

            //Reformat Cost Display
            DisplayFormatedValueText(headPat_cost, Cost);

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

    //Utility helpers
    public static float Round(float value, int digits)
    {
        float mult = Mathf.Pow(10.0f, (float)digits);
        return Mathf.Round(value * mult) / mult;
    }

    //Display Score Rounded
    public static void DisplayFormatedValueText(float score, TextMeshProUGUI DisplayText)
    {   //If over a Million change to M
        if (score >= 1000000)
        {

            float PointsDisplay = ((float)score / 1000000f);
            PointsDisplay = Round(PointsDisplay, 2);

            DisplayText.text = PointsDisplay.ToString() + " M";
        }
        else
        {
            DisplayText.text = score.ToString();
        }
        
    }
}

