using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DreamController : LevelManager
{

    public DreamController(ILevelManagerDependencies dependencies) : base(dependencies)
    {

        // Constructor logic...
    }


    private float hope;
    public GameObject hopeBar;
    public TMP_Dropdown hopeBarDropdown;
    private bool isRunning = true;
    int seconds = 0;


    private void Start()
    {
        hope = 30;
    }
    public void UpdateHope()
    {
        switch (hope)
        {
            case 0:
                hopeBarDropdown.value = 0;
                Lose = true;
                break;
            case 30:
                hopeBarDropdown.value = 1;
                break;
            case 50:
                hopeBarDropdown.value = 2;
                break;
            case 70:
                hopeBarDropdown.value = 3;
                break;
            case 100:
                hopeBarDropdown.value = 4;
                break;
            case 150:
                hopeBarDropdown.value = 5;
                break;
            case 200:
                hopeBarDropdown.value = 6;
                Win = true;
                break;
        }
    }
    protected override void SceneCheck()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        Debug.Log(currentScene.buildIndex.ToString());
        if (currentScene.buildIndex == 2)
        {
            Debug.Log("BBBBBBBBBBBBBBBBBB");
            StartCoroutine(LoseHope());
        }
    }

    private void Update()
    {
        hopeBar.GetComponent<Image>().fillAmount = hope / 200;
        SceneCheck();
        UpdateHope();
        CheckWinClause();
        
    }
    public override void CheckWinClause()
    {
        if (Win)
            Singleton.instance.GetComponent<Game_Manager>().gameState = Game_Manager.GameState.GameWin;
        else if (Lose)
            Singleton.instance.GetComponent<Game_Manager>().gameState = Game_Manager.GameState.GameOver;
        else return;
    }
    IEnumerator LoseHope()
    {
        Debug.Log("Losing Hope");
        
        while (isRunning)
        {
            Debug.Log("Running for " + seconds + " seconds");
            seconds++;
            hope -= 1;
            Debug.Log("Hope is " + hope);
            if (hope == 200 || hope == 0)
            {
                isRunning = false;
                seconds = 0;
            }
            yield return new WaitForSeconds(1f);
        }
    }
    public void Changehopeup(float amount)
    {
        hope += amount;
        hope = Mathf.Clamp(hope, 0f, 200.0f);
    }
}