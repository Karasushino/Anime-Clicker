using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcePortrait : MonoBehaviour
{
    void Awake()
    {
        // Forces the screen to be in portrait mode. That's it. Since it's not set to ScreenOrientation.AutoRotation, the device will NOT auto rotate no mater what.
        Screen.orientation = ScreenOrientation.Portrait;

    }
}
