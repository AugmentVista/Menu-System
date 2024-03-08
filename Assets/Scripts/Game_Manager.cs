using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    [SerializeField] private UIManager uiManager;
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private GameObject spawnPoint;
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject playerArt;
    [SerializeField] private PlayerMovement_2D playerController;

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
    private void MainMenu()
    {
        OnMainMenu?.Invoke();
        Cursor.visible = true;
        playerArt.SetActive(false);
        playerController.enabled = false;
    }
    private void GamePlay()
    {
        OnGamePlay?.Invoke();
        Cursor.visible = false;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }
    private void Pause() 
    {
        OnPause?.Invoke();
        Cursor.visible = true;
        playerArt.SetActive(false);
        playerController.enabled = false;

    }
    private void Options() 
    {
        Cursor.visible = true;
        playerArt.SetActive(false);
        playerController.enabled = false;
    }
    private void GameOver() { OnGameOver?.Invoke(); }
    private void GameWin() { OnGameWin?.Invoke(); }
    public void GameQuit()
    {
        Application.Quit();
    }
}