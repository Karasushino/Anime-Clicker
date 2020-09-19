using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static toggleClickDetection;

public class ToggleSettingPanel : MonoBehaviour
{
    [Header("Gameobject of Panel")]
    [SerializeField]
    private GameObject SettingsPanel;
    [SerializeField]
    private bool isDisplayed = false;

    public void toggleSettingPanel()
    {
        if (!isDisplayed)
        {
            SettingsPanel.SetActive(true);
            isDisplayed = true;
            toggleClickDetection.isClickingDetection = false;
        }
        else
        {
            SettingsPanel.SetActive(false);
            isDisplayed = false;
            toggleClickDetection.isClickingDetection = true;
        }
    }

    public void setNotDisplaying()
    {
        isDisplayed = false;
    }
}
