using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    Game_Manager gameManager;
    [SerializeField]
    private GameObject Player;

    
    void Start()
    {
        gameManager = GetComponent<Game_Manager>();
    }

    //private void LoadScene()
    //{
    //    SceneManager.sceneLoaded += OnSceneLoaded;
    //    if (sceneToLoad != null)
    //    {
    //        if (sceneToLoad.StartsWith("GamePlay"))
    //        {
    //            gameManager.gameState = Game_Manager.GameState.GamePlay;
    //        }
    //        else if (sceneToLoad == "MainMenu")
    //        {
    //            gameManager.gameState = Game_Manager.GameState.MainMenu;
    //        }
    //        else if (sceneToLoad == "EndGame")
    //        {
    //            gameManager.gameState = Game_Manager.GameState.GameWin;
    //        }
    //    }
    //}
}
