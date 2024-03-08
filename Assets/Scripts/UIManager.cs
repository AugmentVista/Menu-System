using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject mainMenuUI;
    public GameObject gamePlayUI;
    public GameObject optionsUI;
    public GameObject pausedUI;
    public GameObject gameOverUI;
    public GameObject gameWinUI;
    public bool WinConditionMet;

    void Start()
    {
        WinConditionMet = false;
        UpdateUI();

        Game_Manager.OnMainMenu += MainMenuUI;
        Game_Manager.OnGamePlay += GamePlayUI;
        Game_Manager.OnGameOver += EndGameUI;
        Game_Manager.OnGameWin += EndGameUI;
        Game_Manager.OnPause += PausedUI;
    }

    private void OnDestroy()
    {
        Game_Manager.OnMainMenu -= MainMenuUI;
        Game_Manager.OnGamePlay -= GamePlayUI;
        Game_Manager.OnGameOver -= EndGameUI;
        Game_Manager.OnGameWin -= EndGameUI;
        Game_Manager.OnPause -= PausedUI;
    }

    private void UpdateUI()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        switch (currentScene.name)
        {
            case "MainMenu":
                MainMenuUI();
                break;
            case "Gameplay1":
            case "Gameplay2":
                GamePlayUI();
                break;
            case "EndGame":
                EndGameUI();
                break;
            default:
                MainMenuUI();
                break;
        }
    }
    private void MainMenuUI()
    {
        HideAllUI();
        mainMenuUI.SetActive(true);
    }
    private void GamePlayUI()
    {
        HideAllUI();
        gamePlayUI.SetActive(true);
    }
    public void OptionsUI()
    {
        HideAllUI();
        optionsUI.SetActive(true);
    }
    private void EndGameUI()
    {
        HideAllUI();
        if (WinConditionMet)
        {
            gameWinUI.SetActive(true);
        }
        else
        {
            gameOverUI.SetActive(true);
        }
    }
    private void PausedUI()
    {
        HideAllUI();
        pausedUI.SetActive(true);
    }
    private void HideAllUI()
    {
        mainMenuUI.SetActive(false);
        gamePlayUI.SetActive(false);
        optionsUI.SetActive(false);
        pausedUI.SetActive(false);
        gameOverUI.SetActive(false);
        gameWinUI.SetActive(false);
    }
}