using UnityEngine;
using UnityEngine.SceneManagement;

public interface ILevelManagerDependencies
{
    GameObject Player { get; }
    Transform PlayerTransform { get; }
    GameObject MainMenuUI { get; }
    GameObject GamePlayUI { get; }
    GameObject GamePlay2UI { get; }
    GameObject OptionsUI { get; }
    GameObject PausedUI { get; }
    GameObject GameOverUI { get; }
    GameObject GameWinUI { get; }
    Camera MenuCamera { get; }
    Camera PlayerCamera { get; }

    // Add other dependencies as needed
}

public class LevelManager : UIManager
{
    private readonly ILevelManagerDependencies dependencies;
    public LevelManager(ILevelManagerDependencies dependencies)
    {
        this.dependencies = dependencies;
    }
    #region InheritedVariables
    public GameObject Player;
    protected Transform PlayerTransform => dependencies.PlayerTransform;
    protected bool Win;
    protected bool Lose;
    private GameObject PlayerRespawnPoint;
    #endregion


    private void Awake()
    {
        SceneManager.activeSceneChanged += SceneCheck;
    }

    #region SceneCalls
    public void LoadMainMenu()
    {
        SceneTransition.LoadMainMenu();
    }
    public void LoadGameplay1()
    {
        SceneTransition.LoadGameplay1();
    }
    public void LoadGameplay2()
    {
        SceneTransition.LoadGameplay2();
    }
    public void LoadGameWin()
    {
        SceneTransition.LoadGameWin();
    }
    public void LoadGameOver()
    {
        SceneTransition.LoadGameOver();
    }
    #endregion

    public virtual void CheckWinClause()
    {
        //if (Win)
        //    Singleton.instance.GetComponent<Game_Manager>().gameState = Game_Manager.GameState.GameWin;
        //else if (Lose)
        //    Singleton.instance.GetComponent<Game_Manager>().gameState = Game_Manager.GameState.GameOver;
        //else return;
    }

    protected virtual void SceneCheck(Scene scene1, Scene scene2) // Only gets called after scene is fully loaded
    {
        Scene currentScene = SceneManager.GetActiveScene();
        switch (currentScene.name)
        {
            case "Gameplay1":
                PlayerRespawnPoint = GameObject.Find("Player Spawn Point");
                PlayerRespawn();
                Game_Manager.ChangeCamera();
                break;
            case "Gameplay2":
                PlayerRespawnPoint = GameObject.Find("Player Spawn Point");
                PlayerRespawn();
                //Game_Manager.ChangeCamera();
                break;
        }
    }

    protected virtual void PlayerRespawn()
    {
        Player.transform.position = PlayerRespawnPoint.transform.position;
    }
}