using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthController : MonoBehaviour
{
    public float health;
    public GameObject healthBar;
    public TMP_Dropdown healthBarDropdown;

    private void Start()
    {
        health = 100;
    }
    public void HealthDropdown()
    {
        switch (healthBarDropdown.value)
        {
            case 0:
                health = 100.0f;
            break;
            case 1:
                health = 75.0f;
            break;
            case 2:
                health = 50.0f;
            break;
            case 3:
                health = 25.0f;
            break;
            case 4:
                health = 0.0f;
            break;
        }
    }
    private void Update()
    {
        healthBar.GetComponent<Image>().fillAmount = health / 100;
    }
    public void ChangeHealthup(float amount)
    {
        health += amount;
        health = Mathf.Clamp(health, 0f, 100.0f);
    }
    public void ChangeHealthdown(float amount)
    {
        health -= amount;
        health = Mathf.Clamp(health, 0f, 100.0f);
    }
}