using UnityEngine;

public class DependenciesExperiment : ILevelManagerDependencies
{
    public GameObject Player { get; }
    public Transform PlayerTransform { get; }
    public GameObject MainMenuUI { get; }
    public GameObject GamePlayUI { get; }
    public GameObject GamePlay2UI { get; }
    public GameObject OptionsUI { get; }
    public GameObject PausedUI { get; }
    public GameObject GameOverUI { get; }
    public GameObject GameWinUI { get; }
    // Implement other dependencies...

    public DependenciesExperiment(GameObject player, Transform playerTransform, GameObject mainMenuUI, GameObject gamePlayUI, GameObject gamePlay2UI, GameObject optionsUI, GameObject pausedUI, GameObject gameOverUI, GameObject gameWinUI)
    {
        Player = player;
        PlayerTransform = playerTransform;
        MainMenuUI = mainMenuUI;
        GamePlayUI = gamePlayUI;
        GamePlay2UI = gamePlay2UI;
        OptionsUI = optionsUI;
        PausedUI = pausedUI;
        GameOverUI = gameOverUI;
        GameWinUI = gameWinUI;
        // Initialize other dependencies...
    }
}
public class DependenciesExperimentInitializer : MonoBehaviour
{
    public GameObject player;
    public Transform  playerTransform;
    public GameObject mainMenuUI;
    public GameObject gamePlayUI;
    public GameObject gamePlay2UI;
    public GameObject optionsUI; 
    public GameObject pausedUI;
    public GameObject gameOverUI;
    public GameObject gameWinUI;

    private void Awake()
    {
        ILevelManagerDependencies dependencies = new DependenciesExperiment(player, playerTransform, mainMenuUI, gamePlayUI, gamePlay2UI, optionsUI, pausedUI, gameOverUI, gameWinUI);
        LevelManager levelManager = new LevelManager(dependencies);
    }
}