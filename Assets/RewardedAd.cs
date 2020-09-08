using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyMobile;
using static ClickerCounter;


public class RewardedAd : MonoBehaviour
{
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
        waifuPoints += 1000000;
    }
    void RewardedAdSkippedHandler(RewardedAdNetwork network, EasyMobile.AdPlacement location)
    {
        Debug.Log("Rewarded ad was skipped. The user should NOT be rewarded.");
    }
}
