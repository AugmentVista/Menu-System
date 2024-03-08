using UnityEngine;
using UnityEngine.SceneManagement;
using static Game_Manager;

public class Game_Manager : MonoBehaviour
{
    [SerializeField] private UIManager uiManager;
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private GameObject spawnPoint;
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject playerArt;
    [SerializeField] private PlayerMovement_2D playerController;
    [SerializeField] private GameObject MenuCamera;
    public bool MenuOpen;

    public enum GameState { MainMenu, GamePlay, Paused, Options, GameOver, GameWin }
    public GameState gameState;


    public delegate void GameStateChange();
    public static event GameStateChange OnMainMenu;
    public static event GameStateChange OnGamePlay;
    public static event GameStateChange OnGameOver;
    public static event GameStateChange OnGameWin;
    public static event GameStateChange OnPause;

    private void Awake()
    {
        playerArt = FindObjectOfType<SpriteRenderer>().gameObject;
        playerController = Player.GetComponent<PlayerMovement_2D>();
    }
    void Update()
    {
        switch (gameState)
        {
            case GameState.MainMenu:
                MainMenu();
                break;
            case GameState.GamePlay:
                GamePlay();
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
    #region Non-states
    public void MainMenuTrigger()
    {
        gameState = GameState.MainMenu;
    }
    public void StartGameTrigger()
    {
        gameState = GameState.GamePlay;
    }
    public void PauseTrigger()
    {
        gameState = GameState.Paused;
    }
    public void OptionsTrigger()
    {
        gameState = GameState.Options;
    }
    public void GameOverTrigger()
    {
        gameState = GameState.GameOver;
    }
    public void GameWinrigger()
    {
        gameState = GameState.GameWin;
    }
    public void Resume()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        switch (currentScene.name)
        {
            case "MainMenu":
                MainMenu();
                break;
            case "Gameplay1":
            case "Gameplay2":
                GamePlay();
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
            playerArt.SetActive(false);
            playerController.enabled = false;
        }
        else if (!MenuOpen)
        {
            MenuCamera.SetActive(false);
            playerArt.SetActive(true);
            playerController.enabled = true;
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
    private void GamePlay()
    {
        Player.SetActive(true);
        MenuIs(false);
        OnGamePlay?.Invoke();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseTrigger();
        }
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