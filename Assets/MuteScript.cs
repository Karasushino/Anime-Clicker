using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MuteScript : MonoBehaviour
{


    //Booleans to mute the audio
    [Header("Booleans to mute audio")]
    [SerializeField]
    private bool isMutedSFX = false;
    [SerializeField]
    private bool isMutedMusic = false;

    [Header("Arrays containing Muted Bar Image")]
    [SerializeField]
    //Index 0 is Music, Index 1 is SFX
    private GameObject[] muteBar;


    [Header("Arrays containing the audio sources")]
    [SerializeField]
    private AudioSource[] MusicSources;
    [SerializeField]
    private AudioSource[] SFXSources;






   public void toggleMuteMusic()
    {
        if (!isMutedMusic)
        {
            //Mute if its unmuted
            for (int i = 0; i < MusicSources.Length; i++)
            {
                MusicSources[i].mute = true;
            }
            //Set mute to true
            isMutedMusic = true;
            muteBar[0].SetActive(true);
        }
        else
        {
            //Unmute if its muted
            for (int i = 0; i < MusicSources.Length; i++)
            {
                MusicSources[i].mute = false;
            }
            //Set mute to false
            isMutedMusic = false;
            muteBar[0].SetActive(false);
        }



    }

   public void toggleMuteSFX()
    {
        if (!isMutedSFX)
        {
            //Mute if its unmuted
            for (int i = 0; i < SFXSources.Length; i++)
            {
                SFXSources[i].mute = true;
            }
            //Set mute to true
            isMutedSFX = true;
            muteBar[1].SetActive(true);
        }
        else
        {
            //Unmute if its muted
            for (int i = 0; i < SFXSources.Length; i++)
            {
                SFXSources[i].mute = false;
            }
            //Set mute to false
            isMutedSFX = false;
            muteBar[1].SetActive(false);
        }



    }
}
