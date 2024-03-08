using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DifficultyController : MonoBehaviour
{
    public float Difficulty;
    public float GamerAmount;
    public float soundSlider;
    public GameObject Sound;
    public GameObject DifficultyBar;
    public GameObject GamerDifficultyBar;
    public TMP_Dropdown DifficultyBarDropdown;
    public void DifficultyUpdate()
    {
        switch (Difficulty) 
        {
            case 20:
                DifficultyBarDropdown.value = 0;
                break;
            case 40:
                DifficultyBarDropdown.value = 1;
                break;
            case 60:
                DifficultyBarDropdown.value = 2;
                break;
            case 80:
                DifficultyBarDropdown.value = 3;
                break;
            case 100:
                DifficultyBarDropdown.value = 4;
                break;
        }
    }
    public void DifficultyDropdown()
    {
        switch (DifficultyBarDropdown.value)
        {
            case 0:
                Difficulty = 20;
                break;
            case 1:
                Difficulty = 40;
                break;
            case 2:
                Difficulty = 60;
                break;
            case 3:
                Difficulty = 80;
                break;
            case 4:
                Difficulty = 100;
                break;
        }
    }
    private void Update()
    {
        DifficultyBar.GetComponent<Image>().fillAmount = Difficulty / 100;
        if (Difficulty >= 80)
        {
            GamerDifficultyBar.GetComponent<Image>().fillAmount = GamerAmount / 20;
            GamerAmount = Difficulty - 80;
            GamerAmount = Mathf.Clamp(GamerAmount, 0f, 20.0f);
        }
        DifficultyUpdate();
    }
    public void ChangeDifficultyup(float amount)
    {
        Difficulty += amount;
        Difficulty = Mathf.Clamp(Difficulty, 0f, 100.0f);
        if (Difficulty >= 80)
        {
            GamerAmount += amount * 5;
        }
    }
    public void ChangeDifficultydown(float amount)
    {
        Difficulty -= amount;
        Difficulty = Mathf.Clamp(Difficulty, 0f, 100.0f);
        if (Difficulty >= 80)
        {
            GamerAmount -= amount * 5;
        }
    }
    public void SoundSlider()
    {
        Sound.GetComponent<Slider>().value = soundSlider / 100;
        soundSlider = Mathf.Clamp(Difficulty, 0f, 100.0f);
    }
}