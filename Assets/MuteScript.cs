using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using BayatGames.SaveGameFree;

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


    private void Awake()
    {
        Load();
    }
    private void OnApplicationQuit()
    {
        Save();
    }
    private void OnApplicationFocus(bool hasFocus)
    {
        if (!hasFocus)
            Save();
    }
    private void OnApplicationPause(bool pause)
    {
        if (pause)
            Save();
    }
    private void Save()
    {
        SaveGame.Save<bool>("isMutedSFX", isMutedSFX);
        SaveGame.Save<bool>("isMutedMusic", isMutedMusic);
        Debug.Log("Saved");
    }

    private void Load()
    {
        isMutedSFX = SaveGame.Load<bool>("isMutedSFX");
        isMutedMusic = SaveGame.Load<bool>("isMutedMusic");

        resetVolumeLoad();
        Debug.Log("Loaded");
    }

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



    public void resetVolumeLoad()
    {
        if (isMutedMusic)
        {
            //Mute
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
            //Unmute
            for (int i = 0; i < MusicSources.Length; i++)
            {
                MusicSources[i].mute = false;
            }
            //Set mute to false
            isMutedMusic = false;
            muteBar[0].SetActive(false);
        }

        if (isMutedSFX)
        {
            //Mute
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
            //Unmute
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
