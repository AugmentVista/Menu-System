using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DreamController : MonoBehaviour
{
    private float hope;
    public GameObject hopeBar;
    public TMP_Dropdown hopeBarDropdown;
    public bool Win;
    public bool Lose;

    private void Start()
    {
        hope = 5000;
    }
    public void UpdateHope()
    {
        switch (hope)
        {
            case 0:
                hopeBarDropdown.value = 0;
                Lose = true;
                break;
            case 5000:
                hopeBarDropdown.value = 1;
                break;
            case 15000:
                hopeBarDropdown.value = 2;
                break;
            case 20000:
                hopeBarDropdown.value = 3;
                break;
            case 25000:
                hopeBarDropdown.value = 4;
                break;
            case 30000:
                hopeBarDropdown.value = 5;
                break;
            case 45000:
                hopeBarDropdown.value = 6;
                Win = true;
                break;
        }
    }
    private void Update()
    {
        hopeBar.GetComponent<Image>().fillAmount = hope / 1000;
        UpdateHope();
        if (hopeBarDropdown.value == 4)
        {
            SceneTransition.LoadEndGame();

        }
    }
    public void Changehopeup(float amount)
    {
        hope += amount;
        hope = Mathf.Clamp(hope, 0f, 45000.0f);
    }
}