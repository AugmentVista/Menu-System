using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class MusicController : MonoBehaviour
{
    public Slider musicSlider;
    public Image musicBar;

    private void Update()
    {
        float musicSliderValue = musicSlider.value / 100f;
        musicBar.fillAmount = musicSliderValue;
        //audioSource.volume = musicSliderValue;
    }
}
