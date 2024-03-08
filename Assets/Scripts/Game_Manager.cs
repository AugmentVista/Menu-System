using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{
    [SerializeField] private UIManager uiManager;
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private GameObject spawnPoint;
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject playerArt;
    [SerializeField] private PlayerMovement_2D playerController;
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
        SceneTransition.LoadMainMenu();
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
                GamePlay();
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
    public void MainMenu()
    {
        OnMainMenu?.Invoke();
        MenuIs(true);
    }
    public void StartGame()
    {
        SceneTransition.LoadGameplay1();
    }
    public void GamePlay()
    {
        OnGamePlay?.Invoke();
        MenuIs(false);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }
    public void Pause() 
    {
        OnPause?.Invoke();
        MenuIs(true);

    }
    public void Options() 
    {
        uiManager.OptionsUI();
        MenuIs(true);
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
    public void GameOver() 
    {
        OnGameOver?.Invoke();
        MenuIs(true);
    }
    public void GameWin() 
    {
        OnGameWin?.Invoke();
        MenuIs(true);
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
            Cursor.visible = true;
            playerArt.SetActive(false);
            playerController.enabled = false;
        }
        else if (!MenuOpen)
        {
            playerArt.SetActive(true);
            playerController.enabled = true;
            Cursor.visible = false;
        }
    }
}