using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class SoundController : MonoBehaviour
{
    public Slider soundSlider;
    public Image soundBar;

    private void Update()
    {
        float soundSliderValue = soundSlider.value / 100f;
        soundBar.fillAmount = soundSliderValue;
        //audioSource.volume = soundSliderValue; 
    }
}

