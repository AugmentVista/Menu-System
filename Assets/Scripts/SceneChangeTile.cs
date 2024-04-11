using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeTile : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        Game_Manager gameManager = Singleton.instance.GetComponent<Game_Manager>();
        Debug.Log("Scene should be changing via collider");
        if (other.CompareTag("Player"))
        {
            Scene currentScene = SceneManager.GetActiveScene();
            if (currentScene.name == "GamePlay1")
            {
                Debug.Log("Attempting scene change");
                Debug.Log("Active scene is " + currentScene.name);
                gameManager.GamePlay2();
            }
        }
    }
}