using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSelectedState : MonoBehaviour
{
    public static Upgrades.Upgrade SelectedUpgrade;
    public void SelectHeadpat()
    {
        SelectedUpgrade = Upgrades.Upgrade.HEADPAT;
        Debug.Log("State Changed To:" + SelectedUpgrade.ToString());
    }

    public void SelectAutoClicker()
    {
        SelectedUpgrade = Upgrades.Upgrade.AUTOCLICKER;
        Debug.Log("State Changed To:" + SelectedUpgrade.ToString());

    }


}
