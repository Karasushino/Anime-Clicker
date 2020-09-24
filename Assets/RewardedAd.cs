using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyMobile;
using static ClickerCounter;
using static Upgrades; 
using TMPro;




public class RewardedAd : MonoBehaviour
{
    public TextMeshProUGUI rewardedAddText;
    [SerializeField]
    [Tooltip("The percentage of your max points that will be added after watching Rewarded A")]
    [Range(0.0f, 1.0f)]
    public float percentageScale = 0.2f;


    float pointsToAdd = 0;



    void OnEnable()
    {
        Advertising.RewardedAdCompleted += RewardedAdCompletedHandler;
        Advertising.RewardedAdSkipped += RewardedAdSkippedHandler;
    }

    // Unsubscribe events
    void OnDisable()
    {
        Advertising.RewardedAdCompleted -= RewardedAdCompletedHandler;
        Advertising.RewardedAdSkipped -= RewardedAdSkippedHandler;
    }

    private void Update()
    {
        //Give the player one time 100k to make them want to watch the ad.
        if (maxWaifuPoints < 100000)
        {
            pointsToAdd = 100000;
        }
        else
            pointsToAdd = percentageScale * ClickerCounter.maxWaifuPoints;
        //Round decimals to nearest int.
        pointsToAdd = Mathf.Round(pointsToAdd);
        Upgrades.DisplayFormatedValueText(pointsToAdd, rewardedAddText, 2);

    }

    public void ShowRewardedAd()
    {
        if (Advertising.IsRewardedAdReady())
        {
            Advertising.ShowRewardedAd();
            Debug.Log("ShowRewardedAd() was ready and called");
        }
        else
        {
            Debug.Log("ShowRewardedAd() was not ready");
        }


    }

    void RewardedAdCompletedHandler(RewardedAdNetwork network, EasyMobile.AdPlacement location)
    {
        //Just ads the points when add completed apparently
        //Increases rewards to make want player watch more ads
        //Potentiall this will be changed from current points to MAX obtained points. 
        ClickerCounter.waifuPoints += pointsToAdd;



    }
    void RewardedAdSkippedHandler(RewardedAdNetwork network, EasyMobile.AdPlacement location)
    {
        Debug.Log("Rewarded ad was skipped. The user should NOT be rewarded.");
    }
}
