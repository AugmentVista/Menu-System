using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject mainMenuUI;
    public GameObject gamePlayUI;
    public GameObject optionsUI;
    public GameObject pausedUI;
    public GameObject gameOverUI;
    public GameObject gameWinUI;


    [SerializeField]
    private GameObject StartButton;
    [SerializeField]
    private GameObject LoadButton;
    [SerializeField]
    private GameObject ExitButton;
    
    void Start()
    {
       
    }
    public void UIMainMenu()
    {
        mainMenuUI.SetActive(true);
        gamePlayUI.SetActive(false);
        optionsUI.SetActive(false);
        pausedUI.SetActive(false);
        gameOverUI.SetActive(false);
        gameWinUI.SetActive(false);
    }
    public void UIGamePlay()
    {
        mainMenuUI.SetActive(false);
        gamePlayUI.SetActive(true);
        optionsUI.SetActive(false);
        pausedUI.SetActive(false);
        gameOverUI.SetActive(false);
        gameWinUI.SetActive(false);
    }
    public void UIOtptions()
    {
        mainMenuUI.SetActive(false);
        gamePlayUI.SetActive(false);
        optionsUI.SetActive(true);
        pausedUI.SetActive(false);
        gameOverUI.SetActive(false);
        gameWinUI.SetActive(false);
    }
    public void UIPasued()
    {
        mainMenuUI.SetActive(false);
        gamePlayUI.SetActive(false);
        optionsUI.SetActive(false);
        pausedUI.SetActive(true);
        gameOverUI.SetActive(false);
        gameWinUI.SetActive(false);
    }
    public void UIGameOver()
    {
        mainMenuUI.SetActive(false);
        gamePlayUI.SetActive(false);
        optionsUI.SetActive(false);
        pausedUI.SetActive(false);
        gameOverUI.SetActive(true);
        gameWinUI.SetActive(false);
    }
    public void UIGameWin()
    {
        mainMenuUI.SetActive(false);
        gamePlayUI.SetActive(false);
        optionsUI.SetActive(false);
        pausedUI.SetActive(false);
        gameOverUI.SetActive(false);
        gameWinUI.SetActive(true);
    }
    void Update()
    {
        
    }
}
