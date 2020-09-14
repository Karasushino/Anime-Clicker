using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyMobile;
using static ClickerCounter;
using TMPro;




public class RewardedAd : MonoBehaviour
{
    public TextMeshProUGUI rewardedAddText;

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
        if (waifuPoints >= 0 && waifuPoints < 10000000)
        {
            rewardedAddText.text = "100K points";
        }
        else if (waifuPoints >= 10000000 && waifuPoints < 100000000)
        {
            rewardedAddText.text = "1.5M points";
        }
        else if (waifuPoints >= 500000000)
        {
            rewardedAddText.text = "50M points";
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
        if (waifuPoints >= 0 && waifuPoints < 10000000)
        {
            waifuPoints += 100000;
        }
        else if (waifuPoints >= 10000000 && waifuPoints < 100000000)
        {
            waifuPoints += 1500000;
        }
        else if(waifuPoints >= 500000000)
        {
            waifuPoints += 50000000;
        }

        
    }
    void RewardedAdSkippedHandler(RewardedAdNetwork network, EasyMobile.AdPlacement location)
    {
        Debug.Log("Rewarded ad was skipped. The user should NOT be rewarded.");
    }
}
