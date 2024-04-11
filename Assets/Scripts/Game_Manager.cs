using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{
    [SerializeField] private UIManager uiManager;
    [SerializeField] private LevelManager levelManager;
    public static GameObject playerCamera;
    public static GameObject menuCamera;
    public GameObject playerCameraLocal;
    public GameObject menuCameraLocal;
    [SerializeField] private GameObject Player;
    public bool Paused;

    public enum GameState { MainMenu, GamePlay1, GamePlay2, Options, GameOver, GameWin }
    public GameState gameState;

    public delegate void GameStateChange();
    public static event GameStateChange OnMainMenu;
    public static event GameStateChange OnGamePlay1;
    public static event GameStateChange OnGamePlay2;
    public static event GameStateChange OnGameOver;
    public static event GameStateChange OnGameWin;

    private void Start()
    {
        playerCamera = playerCameraLocal;
        menuCamera = menuCameraLocal;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && (gameState == GameState.GamePlay1 || gameState == GameState.GamePlay2))
        {
            if (!Paused) // If not paused, pause the game.
            {
                PauseTrigger();
            }
            else // If already paused, resume game.
            {
                ResumeGame();
            }
        }
        CursorToggle();
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
                Debug.Log("Game state has defaulted");
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
        MenuIs(true);
        uiManager.PausedUI();
        Time.timeScale = 0.0f;
        Paused = true;
    }

    public void ResumeGame()
    {
        MenuIs(false);
        uiManager.GamePlayUI();
        Time.timeScale = 1.0f;
        ChangeCamera(true);
        Paused = false;
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
    public void ReloadScene() // Loads selected scene
    {
        Scene currentScene = SceneManager.GetActiveScene();
        switch (currentScene.name)
        {
            case "MainMenu":
                MainMenu();
                break;
            case "GamePlay1":
                GamePlay1();
                break;
            case "GamePlay2":
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
    private void CursorToggle()
    {
        if (playerCamera.activeSelf)
        {
            Cursor.visible = false;
        }
        else if (menuCamera.activeSelf)
        {
            Cursor.visible = true;
        }
    }

    private bool MenuIs(bool open)
    // If a menu is open and the menu camera is turned off it is turned on and the player camera is turned off.
    // If a menu isn't open and the player camera is turned off it is turned on and the menu camera is turned off.
    {
        if (!menuCamera.activeSelf && open)
        {
            ChangeCamera();
            return true;
        }
        else if (!playerCamera.activeSelf && !open)
        {
            ChangeCamera();
            return false;
        }
        else
        {
            //Debug.Log("menuCamera is " + menuCamera.activeSelf + " playerCamera is " + playerCamera.activeSelf);
            return false;
        }
    }
    // Swaps between player camera and menu camera when a menu is opened
    public static void ChangeCamera(bool forceGameplayCam = false) 
    {
        if (forceGameplayCam)
        {
            menuCamera.SetActive(false);
            playerCamera.SetActive(true);
        }
        else if (menuCamera.activeSelf)
        {
            menuCamera.SetActive(false);
            playerCamera.SetActive(true);
        }
        else if (playerCamera.activeSelf)
        {
            menuCamera.SetActive(true);
            playerCamera.SetActive(false);
        }
    }
    #endregion

    #region States
    #region States that trigger scene transitions
    private void MainMenu() 
    {
        OnMainMenu?.Invoke();
        SceneTransition.LoadMainMenu();
        Time.timeScale = 1.0f;
        MenuIs(true);
    }

    private void GamePlay1() 
    {
        SceneTransition.LoadGamePlay1();
        MenuIs(false);
        OnGamePlay1?.Invoke();
    }

    public void GamePlay2() 
    {
        SceneTransition.LoadGamePlay2();
        MenuIs(false);
        OnGamePlay2?.Invoke();
    }
    #endregion
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