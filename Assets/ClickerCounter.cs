using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using BayatGames.SaveGameFree;
using UnityEngine.SceneManagement;


public class ClickerCounter : MonoBehaviour
{



    //All Click Counters and Score VARIABLES

    //TOTAL CLICKER COUNTER
    //Total Number of Clicks = Headpat Score
    public static int totalClicks = 0;

    //ALL BAR RELATED
    //Number of Clicks needed to fill bar
    public static int maxClicks = 12;
    //Offset of % that needs to be filled to show bar
    private static int barOffset = 2;
    //Number of Current Clicks left to fill bar
    public static int numberOfClicks = barOffset;
    //Times the bar has been filled x Upgrade level
    public static float waifuPoints = 0;
    //Top scopre
    public static float maxWaifuPoints = 0;

    [SerializeField]
    private AudioSource headPatSFX;
    [SerializeField]
    private AudioSource FullBarSFX;

    //All UI TEXT AND VALUES 
    //The number that the score will be rounded to when it reaches a Million
    [SerializeField]
    [Tooltip("Number of Significant Figures to Round score to")]
    private int Significant_Figure = 2;

    //Display How many clicks left until bar is filled
    public TextMeshProUGUI currentClicks;
    //Display Total Number of Clicks
    public TextMeshProUGUI HeadpatScore;
    //Display Waifu Points
    public TextMeshProUGUI WaifuScore;
    //Get Particle System that spawns on every click
    public static GameObject tapParticlesObject;
    public static ParticleSystem tapParticle;
    //For now this is here, the sprite that the waifu is on. Probably will be changed to another Script
    //That manages all waifu sprites
    public SpriteRenderer currentSprite;

    private bool isFlipped = false;
    // Start is called before the first frame update
    void Start()
    {
        //Comment Load before Build, also in all places where you load. That will reset the build.
        Load();

        tapParticlesObject = GameObject.Find("Tap Particle");
        tapParticle = tapParticlesObject.GetComponent<ParticleSystem>();


    }

    // Update is called once per frame
    void Update()
    {
        //Only do if we are not in waifu select
        if (toggleClickDetection.isClickingDetection)
        {
            //Check for Mouse Click

            if (Input.GetMouseButtonDown(0))
            {
                headPatSFX.Stop();
                headPatSFX.Play();


                //Spawns Particle on mouse position // Also destroys it
                SpawnParticle();

                //Flip Sprite
                if (!isFlipped)
                {
                    currentSprite.flipX = true;
                    isFlipped = true;
                }

                else
                {
                    currentSprite.flipX = false;
                    isFlipped = false;
                }


                //Increase clicks
                numberOfClicks++;
                totalClicks++;



            }

        }

        //UI UPDATES
        //Displays number of current clicks left to fill bar to get waifu point
        currentClicks.text = (numberOfClicks - barOffset) + "/" + (maxClicks - barOffset);

        //Updates Score UI with formated value to selected significant figure
        Upgrades.DisplayFormatedValueText(totalClicks, HeadpatScore, Significant_Figure);


        //Updates Score UI with formated value to selected significant figure
        Upgrades.DisplayFormatedValueText(waifuPoints, WaifuScore, Significant_Figure);

        //If current clicks filled bar reset bar to empty and add point
        //If over bar then reset it
        if (numberOfClicks > 12)
        {
            numberOfClicks = barOffset;
            //Checks for Data on Points multipliers and adds the points
            Upgrades.addWaifuPoints();


            FullBarSFX.Play();
        }

        //Check if new score is higher than maxScore. This could be changed to check when points are added. But can't be bothered typing 2 times.
        if (maxWaifuPoints < waifuPoints)
        {
            maxWaifuPoints = waifuPoints;
        }


        Save();
    }



    public static void SpawnParticle()
    {
        //Get mouse position and spawn a particle, destroy it after certain amount of time
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 spawnPosition = new Vector3(mousePosition.x, mousePosition.y, 40f);
        Quaternion rotation = new Quaternion(1f, 1f, 1f, -1f);
        ParticleSystem ps = Instantiate(tapParticle, spawnPosition, rotation) as ParticleSystem;
        ps.Play();
        Destroy(ps.gameObject, 1.5f);
    }



    void Save()
    {
        SaveGame.Save<int>("Total Clicks", totalClicks);

        SaveGame.Save<int>("Number Clicks", numberOfClicks);
        SaveGame.Save<float>("Waifu Points", waifuPoints);
        SaveGame.Save<float>("Record Waifu Points", maxWaifuPoints);

    }

    private void Load()
    {
        totalClicks = SaveGame.Load<int>("Total Clicks", totalClicks);

        numberOfClicks = SaveGame.Load<int>("Number Clicks", numberOfClicks);
        waifuPoints = SaveGame.Load<float>("Waifu Points", waifuPoints);
        maxWaifuPoints = SaveGame.Load<float>("Record Waifu Points", maxWaifuPoints);
    }

    public void DebugAddPoints()
    {
        waifuPoints += 100000;
    }

}


   
