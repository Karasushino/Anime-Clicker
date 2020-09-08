using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyMobile;
using UnityEngine.UI;
using static ClickerCounter;


public class AdManager : MonoBehaviour
{

    private float horribleTimer = 10f;
    private float horribleTimerStart = 0f;
    private bool bannerInitialized = false;
    void Awake()
    {
        if (!RuntimeManager.IsInitialized())
        {
            RuntimeManager.Init();
        }

    }


   

    // Update is called once per frame
    void Update()
    {
        //This will only run once...
        //Because of horrible fix...
        InitializeBannerAd();


    }

   
    //Private Functions
    void InitializeBannerAd()
    {
        //All This shit is because it wont start the banner if called on Start
        //Idk if this works I won't have to call it on update all day
        //It's a real pain and I don't get it but fuck it
        //This actually works...
        //I theorize that you have to give it some time before you can actually call the show banner
        //Bug maybe?
        if (!bannerInitialized)
        {
            if (horribleTimerStart <= horribleTimer)
            {
                horribleTimerStart += Time.deltaTime;
            }
            else
            {
                horribleTimerStart = 0f;
                Advertising.ShowBannerAd(BannerAdPosition.Bottom, BannerAdSize.Banner);
                Debug.Log("Banner Should Show now");
                bannerInitialized = true;
            }
        }
        
        
    }

    public void ShowBannerAd()
    {
        Advertising.ShowBannerAd(BannerAdPosition.Bottom, BannerAdSize.Banner);
    }
    public void HideBannerAdd()
    {
        Advertising.HideBannerAd();
    }
}
