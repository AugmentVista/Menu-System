using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthController : MonoBehaviour
{
    private float health;
    public GameObject healthBar;
    public TMP_Dropdown healthBarDropdown;

    private void Start()
    {
        health = 20;
    }
    //public void HealthDropdown()
    //{
    //    switch (healthBarDropdown.value)
    //    {
    //        case 0:
    //            health = 100.0f;
    //        break;
    //        case 1:
    //            health = 75.0f;
    //        break;
    //        case 2:
    //            health = 50.0f;
    //        break;
    //        case 3:
    //            health = 25.0f;
    //        break;
    //        case 4:
    //            health = 0.0f;
    //        break;
    //    }
    //}
    public void HealthUpdate()
    {
        switch (health)
        {
            case 100:
                healthBarDropdown.value = 0;
                break;
            case 80:
                healthBarDropdown.value = 1;
                break;
            case 60:
                healthBarDropdown.value = 2;
                break;
            case 40:
                healthBarDropdown.value = 3;
                break;
            case 20:
                healthBarDropdown.value = 4;
                break;
        }
    }
    private void Update()
    {
        healthBar.GetComponent<Image>().fillAmount = health / 100;
        HealthUpdate();
        if (healthBarDropdown.value == 4)
        {
            SceneTransition.LoadGameplay2();
        
        }
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