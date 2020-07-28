using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggleClickDetection : MonoBehaviour
{
    //This script is going to be pretty dumb but here it goes
    //THIS DEACTIVATES ADDING A HEADPAT WHEN CLICKING
    //USEFUL FOR MENUS AND PLACES WHERE YOU DON'T WANT THE POINTS TO BE ADDED
    //Also deactivates the spawn particles since you are not clicking anymore

    //Get ready for this super complex code


    //Yes by default
    public static bool isClickingDetection = true;

    private void Start()
    {
        //Prevent screen from sleeping
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }
    public void setClickingDetectionOFF()
    {
        isClickingDetection = false;
    }

    public void setClickingDetectionON()
    {
        isClickingDetection = true;
    }

}
