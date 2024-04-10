using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : UIManager
{
    public GameObject Player;
    public Transform PlayerTransform;
    public bool Win;
    public bool Lose;
    public GameObject PlayerRespawnPoint;


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

    public void CheckWinClause()
    {
        if (Win)
            Singleton.instance.GetComponent<Game_Manager>().gameState = Game_Manager.GameState.GameWin;
        else if (Lose)
            Singleton.instance.GetComponent<Game_Manager>().gameState = Game_Manager.GameState.GameOver;
        else return;
    }

    public void SceneCheck(Scene scene1, Scene scene2) // Only gets called after scene is fully loaded
    {
        Scene currentScene = SceneManager.GetActiveScene();
        switch (currentScene.name)
        {
            case "Gameplay1":
                PlayerRespawnPoint = GameObject.Find("Player Spawn Point");
                Game_Manager.menuCamera.gameObject.SetActive(false);
                break;
            case "Gameplay2":
                PlayerRespawnPoint = GameObject.Find("Player Spawn Point");
                Game_Manager.menuCamera.gameObject.SetActive(false);
                break;
            default:
                // The only other scenes that matter are MainMenu, GameWin and GameOver
                break;
        }

        if (PlayerRespawnPoint)
            PlayerRespawn();
        else
            Debug.Log("There is no Player Spawn Point object in this scene");
    }

    public void PlayerRespawn()
    {
        if (Player != null)
        Player.transform.position = PlayerRespawnPoint.transform.position;
    }
}