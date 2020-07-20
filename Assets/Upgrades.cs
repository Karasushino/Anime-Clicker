using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;



public class Upgrades : MonoBehaviour
{



    //Acts as a multiplyer of waifu 
    [SerializeField]
    private static int headPat_level = 1;
    [SerializeField]
    private int headPat_cost;
    //The percentage increased on the cost of the upgrade
    [SerializeField]
    private int headPat_cost_multiplier = 20;

    enum Upgrade
    {
        HEADPAT,
        TEST

    }

    public  TextMeshProUGUI UpgradeTitle;
    public  TextMeshProUGUI UpgradeDescription;
    public  TextMeshProUGUI Level;
    public  TextMeshProUGUI Cost;

    Upgrade upgradeType = Upgrade.HEADPAT;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch (upgradeType)
        {
            case Upgrade.HEADPAT:
                displayHeadpatUpgrade();
                break;
            case Upgrade.TEST:
                displayTESTUpgrade();
                break;
        }



    }

    public void displayHeadpatUpgrade()
    {
        UpgradeTitle.text = "Better Headpats";
        UpgradeDescription.text = "Headpats = waifu points";
        Level.text = headPat_level.ToString();
        Cost.text = headPat_cost.ToString();
    }
    public void displayTESTUpgrade()
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
            headPat_cost += (headPat_cost * headPat_cost_multiplier)/100;

            //Update new values
            Level.text = headPat_level.ToString();
            Cost.text = headPat_cost.ToString();
        }
    }

    public static void addWaifuPoints()
    {
        //Adds waifu Points based on the level
        ClickerCounter.waifuPoints += 1 * headPat_level;
    }
}
