using UnityEngine;

public class DependenciesExperiment : ILevelManagerDependencies
{
    public Transform PlayerTransform { get; }
    public GameObject MainMenuUI { get; }
    public GameObject GamePlayUI { get; }
    public GameObject GamePlay2UI { get; }
    public GameObject OptionsUI { get; }
    public GameObject PausedUI { get; }
    public GameObject GameOverUI { get; }
    public GameObject GameWinUI { get; }
    // Implement other dependencies...

    public DependenciesExperiment(Transform playerTransform, GameObject mainMenuUI, GameObject gamePlayUI, GameObject gamePlay2UI, GameObject optionsUI, GameObject pausedUI, GameObject gameOverUI, GameObject gameWinUI)
    {
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
    public Transform playerTransform;
    public GameObject mainMenuUI;
    public GameObject gamePlayUI;
    public GameObject gamePlay2UI;
    public GameObject optionsUI; // Fix typo here
    public GameObject pausedUI;
    public GameObject gameOverUI;
    public GameObject gameWinUI;

    private void Awake()
    {
        ILevelManagerDependencies dependencies = new DependenciesExperiment(playerTransform, mainMenuUI, gamePlayUI, gamePlay2UI, optionsUI, pausedUI, gameOverUI, gameWinUI);
        LevelManager levelManager = new LevelManager(dependencies);
    }
}