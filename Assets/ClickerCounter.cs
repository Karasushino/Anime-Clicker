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
    private static int barOffset = 2;
    // Start is called before the first frame update
    void Start()
    {
        numberOfClicks = barOffset;
        
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 spawnPosition = new Vector3(mousePosition.x, mousePosition.y, 40f);
            Quaternion rotation = new Quaternion(1f, 1f, 1f, -1f);
            ParticleSystem ps = Instantiate(heartsParticles, spawnPosition, rotation) as ParticleSystem;
            ps.Play();
            Destroy(ps.gameObject, 1.5f);
           




            numberOfClicks++;
            totalClicks++;
            if (numberOfClicks > 12)
            {
                numberOfClicks = barOffset;
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
}
