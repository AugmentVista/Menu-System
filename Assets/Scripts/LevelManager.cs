using UnityEngine;
using UnityEngine.SceneManagement;



public interface ILevelManagerDependencies
{
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
    public static GameObject Player;
    protected bool Win;
    protected bool Lose;
    protected Transform PlayerTransform = Player.GetComponent<Transform>();
    protected Sprite PlayerSprite = Player.GetComponent<SpriteRenderer>().sprite;
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
    public void LoadGameLose()
    {
        SceneTransition.LoadGameLose();
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
        if (Win)
            GameWinUI();
        else if (Lose)
            GameLoseUI();
        else return;
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
        Player.transform.position = Vector3.zero;
    }
}
