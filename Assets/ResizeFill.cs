using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResizeFill : MonoBehaviour
{
    public Slider Slider;

    // Start is called before the first frame update
    void Start()
    {
        Slider.maxValue = ClickerCounter.maxClicks;
        Slider.value = ClickerCounter.numberOfClicks;
    }

    // Update is called once per frame
    void Update()
    {
        Slider.value = ClickerCounter.numberOfClicks;
    }
}
