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

    // Add other dependencies as needed...
}


public class LevelManager : UIManager
{
    private readonly ILevelManagerDependencies dependencies;

    public LevelManager(ILevelManagerDependencies dependencies)
    {
        this.dependencies = dependencies;
    }

    #region InheritedVariables
    protected GameObject player => dependencies.Player;
    protected Transform playerTransform => dependencies.PlayerTransform;
    protected bool Win;
    protected bool Lose;
    #endregion

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

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
        }
    }
    public virtual void CheckWinClause()
    {
        //if (Win)
        //    Singleton.instance.GetComponent<Game_Manager>().gameState = Game_Manager.GameState.GameWin;
        //else if (Lose)
        //    Singleton.instance.GetComponent<Game_Manager>().gameState = Game_Manager.GameState.GameOver;
        //else return;
    }
    protected virtual void SceneCheck()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "ExampleScene")
        {
            // code for entering that scene here
        }
        else { return; }
    }
    protected virtual void PlayerToSpawnPoint() 
    { 
        player.transform.position = Vector3.zero;
    }
}