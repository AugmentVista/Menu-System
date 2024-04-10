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

    public enum GameState { MainMenu, GamePlay1, GamePlay2, Paused, Options, GameOver, GameWin }
    public GameState gameState;

    public delegate void GameStateChange();
    public static event GameStateChange OnMainMenu;
    public static event GameStateChange OnGamePlay1;
    public static event GameStateChange OnGamePlay2;
    public static event GameStateChange OnGameOver;
    public static event GameStateChange OnGameWin;
    public static event GameStateChange OnPause;

    private void Start()
    {
        playerCamera = playerCameraLocal;
        menuCamera = menuCameraLocal;
    }
    void Update()
    {
        // The additional () ensures this adheres to PEDMAS. The gameState checks first as either, then ESC pressed is checked.
        if (Input.GetKeyDown(KeyCode.Escape) && (gameState == GameState.GamePlay1 || gameState == GameState.GamePlay2 ))
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
    // You cannot pause while in a menu, only if MenuOpen is false does the pause occur.
    // Changing GameState to paused calls Pause() which sets MenuOpen to true.
    {
        if (MenuIs(true))
        {
            return;
        }
        else
        {
            gameState = GameState.Paused;
            ChangeGameState(gameState);
        }
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

    public void Resume() // Sets MenuIs to false while there is a menuCamera active meaning there is no playercamera
    {
        MenuIs(false);
    }

    private bool MenuIs(bool open)
    // If a menu is open and the menu camera is turned off it is turned on and the player camera is turned off.
    // If a menu isn't open and the player camera is turned off it is turned on and the menu camera is turned off.
    {
        if (!menuCamera && open)
        {
            ChangeCamera();
            Cursor.visible = true;
            return true;
        }
        if (!playerCamera && !open) 
        {
            ChangeCamera();
            Cursor.visible = false;
            return false;
        }
        Debug.Log("MenuIs() is not working");
        Debug.Log("menuCamera is " + menuCamera.activeSelf + " playerCamera is " + playerCamera.activeSelf );
        return false;
    }
    public static void ChangeCamera() // Swaps between player camera and menu camera when a menu is opened
    {
        if (menuCamera.gameObject.activeSelf)
        {
            menuCamera.gameObject.SetActive(false);
            playerCamera.gameObject.SetActive(true);
            return;
        }
        else if (playerCamera.gameObject.activeSelf)
        {
            menuCamera.gameObject.SetActive(true);
            playerCamera.gameObject.SetActive(false);
            return;
        }
    }
    #endregion

    #region States
    #region States that trigger scene transitions
    private void MainMenu() 
    {
        OnMainMenu?.Invoke();
        SceneTransition.LoadMainMenu();
        MenuIs(true);
    }

    private void GamePlay1() 
    {
        SceneTransition.LoadGameplay1();
        MenuIs(false);
        OnGamePlay1?.Invoke();
    }

    public void GamePlay2() 
    {
        SceneTransition.LoadGameplay2();
        MenuIs(false);
        OnGamePlay2?.Invoke();
    }
    #endregion

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