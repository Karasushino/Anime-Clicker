using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX_script : MonoBehaviour
{
    [SerializeField]
    private AudioSource MainTheme;
    [SerializeField]
    private AudioSource MenuClick;
    [SerializeField]
    private AudioSource WaifuTheme;
    public void playMainTheme()
    {
        MainTheme.Play();
    }

    public void stopMainTheme()
    {
        MainTheme.Stop();
    }

    public void playWaifuTheme()
    {
        WaifuTheme.Play();
    }

    public void stopWaifuTheme()
    {
        WaifuTheme.Stop();
    }


    public void playMenuClick()
    {
        MenuClick.Play();
    }

    public void stopMenuClick()
    {
        MenuClick.Stop();
    }

}
