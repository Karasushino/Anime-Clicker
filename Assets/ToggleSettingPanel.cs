using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSettingPanel : MonoBehaviour
{
    [Header("Gameobject of Panel")]
    [SerializeField]
    private GameObject SettingsPanel;
    [SerializeField]
    private bool isDisplayed = false;

    public void toggleSettingPanel()
    {
        if(!isDisplayed)
        {
            SettingsPanel.SetActive(true);
            isDisplayed = true;
        }
        else
        {
            SettingsPanel.SetActive(false);
            isDisplayed = false;
        }
    }

}
