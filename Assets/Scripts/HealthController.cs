using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class HealthController : LevelManager
{

    public HealthController(ILevelManagerDependencies dependencies) : base(dependencies)
    {
        // Constructor logic...
    }

    private float health;
    public GameObject healthBar;
    public TMP_Dropdown healthBarDropdown;

    private void Start()
    {
        Game_Manager.OnGamePlay1 += ResetScene;
        ResetScene();
    }

    private void ResetScene()
    {
        health = 20;
    }

    public void HealthUpdate()
    {
        switch (health)
        {
            case 20:
                healthBarDropdown.value = 0;
                break;
            case 40:
                healthBarDropdown.value = 1;
                break;
            case 60:
                healthBarDropdown.value = 2;
                break;
            case 80:
                healthBarDropdown.value = 3;
                break;
            case 100:
                healthBarDropdown.value = 4;
                Win = true;
                break;
        }
    }
    public override void CheckWinClause()
    {
        if (Win)
        {
            Debug.Log("Has Won First Game");
            Singleton.instance.GetComponent<Game_Manager>().GamePlay2();
            Win = false;
        }
        else if (!Win)
        return;
    }
    private void Update()
    {
        if (!Win) // Purely to remove the number of things being updated
        {
        healthBar.GetComponent<Image>().fillAmount = health / 100;
        HealthUpdate();
        CheckWinClause();
            Debug.Log("Are we there yet Mr.Krabs?");
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