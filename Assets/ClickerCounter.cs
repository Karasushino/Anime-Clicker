using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClickerCounter : MonoBehaviour
{
    public static int numberOfClicks;
    public static int totalClicks = 0;
    public static int maxClicks = 12;
    public static int waifuPoints = 0;
    public TextMeshProUGUI currentClicks;
    public TextMeshProUGUI HeadpatScore;
    public TextMeshProUGUI WaifuScore;
    public ParticleSystem heartsParticles;
    public SpriteRenderer currentSprite;
    private static int barOffset = 2;
    private bool isFlipped = false;
    // Start is called before the first frame update
    void Start()
    {
        numberOfClicks = barOffset;
        
    }

    // Update is called once per frame
    void Update()
    {
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
        //Displays number of current clicks left to fill bar to get waifu point
        currentClicks.text = (numberOfClicks - barOffset) + "/" + (maxClicks - barOffset);
        //Set Headpat Counter
        HeadpatScore.text = totalClicks.ToString();
        //Set Waifu Score
        WaifuScore.text = waifuPoints.ToString();
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
}

