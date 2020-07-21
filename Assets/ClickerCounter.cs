using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



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
    public static float waifuPoints = 100000000f;

    //All UI TEXT AND VALUES 
    //The number that the score will be rounded to when it reaches a Million
    [SerializeField]
    [Tooltip("Number of Significant Figures to Round score to")]
    private int Significant_Figure = 5;

    //Display How many clicks left until bar is filled
    public TextMeshProUGUI currentClicks;
    //Display Total Number of Clicks
    public TextMeshProUGUI HeadpatScore;
    //Display Waifu Points
    public TextMeshProUGUI WaifuScore;
    //Get Particle System that spawns on every click
    public ParticleSystem heartsParticles;
    //For now this is here, the sprite that the waifu is on. Probably will be changed to another Script
    //That manages all waifu sprites
    public SpriteRenderer currentSprite;
   
    private bool isFlipped = false;
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {   //Check for Mouse Click
        if (Input.GetMouseButtonDown(0))
        {
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
            //If over bar then reset it
            if (numberOfClicks > 12)
            {
                numberOfClicks = barOffset;
                //Checks for Data on Points multipliers and adds the points
                Upgrades.addWaifuPoints();
            }

        }

        UpdateScoreText();
    }

    void SpawnParticle()
    {
        //Get mouse position and spawn a particle, destroy it after certain amount of time
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 spawnPosition = new Vector3(mousePosition.x, mousePosition.y, 40f);
        Quaternion rotation = new Quaternion(1f, 1f, 1f, -1f);
        ParticleSystem ps = Instantiate(heartsParticles, spawnPosition, rotation) as ParticleSystem;
        ps.Play();
        Destroy(ps.gameObject, 1.5f);
    }
   

//Also Reformats text
void UpdateScoreText()
    {

        //Displays number of current clicks left to fill bar to get waifu point
        currentClicks.text = (numberOfClicks - barOffset) + "/" + (maxClicks - barOffset);
        //When reached a Million change Score to M
        if (waifuPoints >= 1000000)
        {

            float waifuPointsDisplay = ((float)waifuPoints / 1000000f);
            waifuPointsDisplay = Round(waifuPointsDisplay, Significant_Figure);
           
            WaifuScore.text = waifuPointsDisplay.ToString() + " M";
        }
        else
        {
            WaifuScore.text = waifuPoints.ToString();
        }
        //Set Headpat Counter
        HeadpatScore.text = totalClicks.ToString();

    }
    //From google, way to aproximate to significant figure 


    public static float Round(float value, int digits)
    {
        float mult = Mathf.Pow(10.0f, (float)digits);
        return Mathf.Round(value * mult) / mult;
    }
}