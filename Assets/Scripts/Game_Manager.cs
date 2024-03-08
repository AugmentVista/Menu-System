using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{
    [SerializeField] private UIManager uiManager;
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private GameObject MenuCamera;
    [SerializeField] private GameObject Player;
    public bool MenuOpen;

    public enum GameState { MainMenu, GamePlay1, GamePlay2, Paused, Options, GameOver, GameWin }
    public GameState gameState;

    public delegate void GameStateChange();
    public static event GameStateChange OnMainMenu;
    public static event GameStateChange OnGamePlay1;
    public static event GameStateChange OnGamePlay2;
    public static event GameStateChange OnGameOver;
    public static event GameStateChange OnGameWin;
    public static event GameStateChange OnPause;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && gameState != GameState.MainMenu)
        {
            PauseTrigger();
        }
    }
    public void ChangeGameState(GameState state)
    {
        switch (state)
        {
            case GameState.MainMenu:
                MainMenu();
                break;
            case GameState.GamePlay1:
                GamePlay1();
                break;
            case GameState.GamePlay2:
                GamePlay2();
                break;
            case GameState.Paused:
                Pause();
                break;
            case GameState.Options:
                Options();
                break;
            case GameState.GameOver:
                GameOver();
                break;
            case GameState.GameWin:
                GameWin();
                break;
            default:
                MainMenu();
                break;
        }
    }

    #region Non states

    #region UI Triggers
    public void MainMenuTrigger()
    {
        gameState = GameState.MainMenu;
        ChangeGameState(gameState);
    }
    public void StartGameTrigger()
    {
        gameState = GameState.GamePlay1;
        ChangeGameState(gameState);
    }
    public void PauseTrigger()
    {
        gameState = GameState.Paused;
        ChangeGameState(gameState);
    }
    public void OptionsTrigger()
    {
        gameState = GameState.Options;
        ChangeGameState(gameState);
    }
    public void GameOverTrigger()
    {
        gameState = GameState.GameOver;
        ChangeGameState(gameState);
    }
    public void GameWinTrigger()
    {
        gameState = GameState.GameWin;
        ChangeGameState(gameState);
    }
    #endregion
    public void Resume()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        switch (currentScene.name)
        {
            case "MainMenu":
                MainMenu();
                break;
            case "Gameplay1":
                GamePlay1();
                break;
            case "Gameplay2":
                GamePlay2();
                break;
            default:
                MainMenu();
                break;
        }
    }
    public void GameQuit()
    {
        Application.Quit();
    }
    private void MenuIs(bool open)
    {
        MenuOpen = open;
        if (MenuOpen)
        {
            MenuCamera.SetActive(true);
            Cursor.visible = true;
        }
        else if (!MenuOpen)
        {
            MenuCamera.SetActive(false);
            Cursor.visible = false;
        }
    }
    #endregion

    #region States
    private void MainMenu()
    {
        OnMainMenu?.Invoke();
        SceneTransition.LoadMainMenu();
        MenuIs(true);
    }
    private void GamePlay1()
    {
        Player.SetActive(true);
        SceneTransition.LoadGameplay1();
        MenuIs(true);
        OnGamePlay1?.Invoke();
        
    }
    private void GamePlay2()
    {
        Player.SetActive(true);
        SceneTransition.LoadGameplay2();
        MenuIs(true);
        OnGamePlay2?.Invoke();
    }
    private void Pause() 
    {
        OnPause?.Invoke();
        MenuIs(true);
    }
    private void Options() 
    {
        uiManager.OptionsUI();
        MenuIs(true);
    }
    private void GameOver() 
    {
        OnGameOver?.Invoke();
        MenuIs(true);
    }
    private void GameWin() 
    {
        OnGameWin?.Invoke();
        MenuIs(true);
    }
    #endregion
}