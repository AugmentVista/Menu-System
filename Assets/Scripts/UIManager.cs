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
    public GameObject gamePlay2UI;

    void Start()
    {
        UpdateUI();
        Game_Manager.OnMainMenu += MainMenuUI;
        Game_Manager.OnGamePlay += GamePlayUI;
        Game_Manager.OnGameOver += GameWinUI;
        Game_Manager.OnGameWin += GameWinUI;
        Game_Manager.OnPause += PausedUI;
    }

    private void OnDestroy()
    {
        Game_Manager.OnMainMenu -= MainMenuUI;
        Game_Manager.OnGamePlay -= GamePlayUI;
        Game_Manager.OnGameOver -= GameWinUI;
        Game_Manager.OnGameWin -= GameWinUI;
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
            case "GameWin":
                GameWinUI();
                break;
            case "GameLose":
                GameWinUI();
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
    private void GamePlay2UI()
    {
        HideAllUI();
        gamePlayUI.SetActive(true);
    }
    public void OptionsUI()
    {
        HideAllUI();
        optionsUI.SetActive(true);
    }
    protected void GameWinUI()
    {
        HideAllUI();
        gameWinUI.SetActive(true);
    }
    protected void GameLoseUI()
    {
        HideAllUI();
        gameWinUI.SetActive(true);
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
        gamePlay2UI.SetActive(false);
        optionsUI.SetActive(false);
        pausedUI.SetActive(false);
        gameOverUI.SetActive(false);
        gameWinUI.SetActive(false);
    }
}