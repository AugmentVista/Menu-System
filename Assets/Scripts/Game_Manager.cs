using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    
    [SerializeField]
    private UIManager uiManager;
    [SerializeField]
    private LevelManager levelManager;
    [SerializeField]
    private Game_Manager gameManager;
    [SerializeField]
    private GameObject spawnPoint;
    [SerializeField]
    private GameObject Player;
    [SerializeField]
    private GameObject playerArt;


    //private SerializeField levelManager;
    //private SerializeField uiManager;
    //private SerializeField playerController;

    public enum GameState {MainMenu, GamePlay, Paused, Options, GameOver, GameWin }
    public GameState gameState;


    public void Awake() // optional if using serialized fields
    {
        //gameManager = FindAnyObjectByType<Game_Manager>();
        //levelManager = FindAnyObjectByType<LevelManager>();
        //uiManager = FindAnyObjectByType<UIManager>();
        //playerController = FindAnyObjectByType<PlayerMovement_2D>();
        //spawnPoint = GameObject.FindWithTag("SpawnPoint");
        playerArt = FindObjectOfType<SpriteRenderer>().gameObject;
    }
    void Update()
    {
        switch (gameState)
        { 
        case GameState.MainMenu: MainMenu(); break;
        case GameState.GamePlay: GamePlay(); break;
        }
    }
    private void MainMenu()
    { 
        Cursor.visible = true;
        //playerArt.SetActive(false);
        //playerController.enabled = false;
        //uiManager.UIMainMenu();
    }
    private void GamePlay()
    {
        Cursor.visible = false;
        //uiManager.UIGamePlay();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // game go!
        }
    }
    public void GameQuit()
    {
        Application.Quit();
    }
    public void PlayerToSpawnPoint()
    { 
    
    
    
    }
}
