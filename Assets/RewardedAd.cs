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
    [Tooltip("The range between stages of points IN MILLIONS")]
    private float[] RewardStagesRange;
    [SerializeField]
    [Tooltip("REWARD AFTER WATCHING AD IN MILLIONS")]
    private float[] RewardStagesAmount;

    float pointsToAdd = 0;


    private void Start()
    {
        for(int i = 0; i < RewardStagesAmount.Length;i++)
        {
            //Make everything in the millions range
            RewardStagesAmount[i] *= 1000000.0f;
        }
        for (int i = 0; i < RewardStagesRange.Length; i++)
        {
            //Make everything in the millions range
            RewardStagesRange[i] *= 1000000.0f;
        }
    }
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
        
        for (int i = 0; i < RewardStagesRange.Length; i++)
        {
            //If it goes out of bound it means it doesn't need checking. End point has been found.
            if (i + 1 > RewardStagesRange.Length) 
            {
                return;
            }
            //Check the 1st range and the next range.
            else if (maxWaifuPoints >= RewardStagesRange[i] && maxWaifuPoints < RewardStagesRange[i+1])
            {
                pointsToAdd = RewardStagesAmount[i];
                Upgrades.DisplayFormatedValueText(pointsToAdd, rewardedAddText, 2);
                Debug.Log("Points to Add" + pointsToAdd.ToString());
            }
        }

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
