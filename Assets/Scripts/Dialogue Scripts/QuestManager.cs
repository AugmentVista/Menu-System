using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class QuestManager : MonoBehaviour
{
    public GameObject DialogueParent;
    public Image DialogueBackground;
    public TextMeshProUGUI Dialogue;
    Scene currentScene;
    public static bool isTalking = false;
    public float questsCompleted;
    public float totalQuests = 5;

    private GameObject[] Obstacles;
    private GameObject[] eyeObjects;

    public List<InteractionObject.Pickups> inventory = new();

    public List<InteractionObject.Pickups> coinInventory = new List<InteractionObject.Pickups>();
    public List<InteractionObject.Pickups> eyesInventory = new List<InteractionObject.Pickups>();
    public List<InteractionObject.Pickups> bootsInventory = new List<InteractionObject.Pickups>();

    private int eyeCount;

    private void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void ProgressCheck()
    {
        if (currentScene.name == "GamePlay2" || currentScene.name == "GamePlay1")
        {
            Debug.Log("eye count: " + eyeCount);
            Debug.Log("eyes inventory count: " + eyesInventory.Count);
            foreach (GameObject obstacle in Obstacles)
            {
                Debug.Log(obstacle.name);
                if (obstacle.name == "First Obstacle" && eyeCount == eyesInventory.Count && questsCompleted < 1)
                {
                    obstacle.SetActive(true);
                    questsCompleted++;
                }
            }
        }
        else return;
    }
   
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        inventory = new();
        currentScene = scene;

        Obstacles = GameObject.FindGameObjectsWithTag("Obstacle");

        if (scene.name == "GamePlay2")
        {
            eyesInventory = new();
            eyeObjects = GameObject.FindGameObjectsWithTag("Eye");
            eyeCount = eyeObjects.Length;
        }

        if (Obstacles != null)
        {
            foreach (GameObject obstacle in Obstacles)
            {
                if (obstacle.name == "First Obstacle")
                    obstacle.SetActive(false);
            }
        }
    }
}