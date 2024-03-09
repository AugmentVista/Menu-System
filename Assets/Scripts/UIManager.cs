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
        Game_Manager.OnGamePlay1 += GamePlay1UI;
        Game_Manager.OnGamePlay2 += GamePlay2UI;
        Game_Manager.OnGameOver += GameWinUI;
        Game_Manager.OnGameWin += GameWinUI;
        Game_Manager.OnPause += PausedUI;
    }

    private void OnDestroy()
    {
        Game_Manager.OnMainMenu -= MainMenuUI;
        Game_Manager.OnGamePlay1 -= GamePlay1UI;
        Game_Manager.OnGamePlay1 -= GamePlay2UI;
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
                GamePlay1UI();
                break;
            case "Gameplay2":
                GamePlay2UI();
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
    private void GamePlay1UI()
    {
        HideAllUI();
        gamePlayUI.SetActive(true);
    }
    private void GamePlay2UI()
    {
        HideAllUI();
        gamePlay2UI.SetActive(true);
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
    protected void GameOverUI()
    {
        HideAllUI();
        gameOverUI.SetActive(true);
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