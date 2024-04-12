using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Threading;
using System.Collections;

public class DifficultyController : MonoBehaviour
{
    public float Difficulty;
    public float GamerAmount;
    public float soundSlider;
    public GameObject Sound;
    public GameObject DifficultyBar;
    public GameObject GamerDifficultyBar;
    public TMP_Dropdown DifficultyBarDropdown;
    public Timer FinalCountDown;
    private bool isCountdownReducing = false;

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
    private void Update()
    {
        DifficultyBar.GetComponent<Image>().fillAmount = Difficulty / 100;
        if (Difficulty >= 80)
        {
            GamerDifficultyBar.GetComponent<Image>().fillAmount = GamerAmount / 20;
            GamerAmount = Difficulty - 80;
            GamerAmount = Mathf.Clamp(GamerAmount, 0f, 20.0f);
        }
        if (GamerAmount > 0.1f && !isCountdownReducing && FinalCountDown != null)
        {
            StartCoroutine(ReduceCountdown());
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

    private IEnumerator ReduceCountdown()
    {
        isCountdownReducing = true;

        // Calculate the amount to subtract from the timer (up to 20 seconds)
        float countdownReduction = Mathf.Min(GamerAmount, 20f);

        // Wait for a short delay before starting the countdown reduction
        yield return new WaitForSeconds(1f);

        // Subtract the calculated amount from the timer every second
        while (countdownReduction > 0 && FinalCountDown != null)
        {
            //FinalCountDown.ChangeTime(-1f); ChangeTime doesn't exist find another solution
            countdownReduction -= 1f;
            yield return new WaitForSeconds(1f);
        }

        isCountdownReducing = false;
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