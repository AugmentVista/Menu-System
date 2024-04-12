using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class QuestManager : MonoBehaviour
{
    Scene currentScene;
    public GameObject DialogueParent;
    public Image DialogueBackground;
    public TextMeshProUGUI Dialogue;
    public static bool isTalking = false;
    public float questsCompleted;
    public float totalQuests = 5;

    public GameObject Inventory;
    public GameObject eyesSprite;
    public GameObject ringSprite;
    public GameObject bootsSprite;
    public GameObject helmetSprite;

    public TextMeshProUGUI eyesUICount; 
    public TextMeshProUGUI ringUICount;
    public TextMeshProUGUI bootsUICount;
    public TextMeshProUGUI helemtUICount;

    private int eyeCount;
    private int ringCount;
    private int bootsCount;
    private int helmetCount;

    private GameObject[] Obstacles;
    private GameObject[] eyeObjects;
    private GameObject[] ringObjects;
    private GameObject[] bootsObjects;
    private GameObject[] helmetObjects;
    private GameObject[] NPCs;

    public List<InteractionObject.Pickups> inventory = new();

    public List<InteractionObject.Pickups> eyesInventory = new List<InteractionObject.Pickups>();
    public List<InteractionObject.Pickups> ringInventory = new List<InteractionObject.Pickups>();
    public List<InteractionObject.Pickups> bootsInventory = new List<InteractionObject.Pickups>();
    public List<InteractionObject.Pickups> helmetInventory = new List<InteractionObject.Pickups>();


    private void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void ProgressCheck()
    {
        if (currentScene.name == "GamePlay2" || currentScene.name == "GamePlay1")
        {
            QuestObstacleHandler();
            NPCAdvanceDialogue();
        }
        else return;
    }

    private void Update()
    {
        UpdateItemsUI();
    }
    private void QuestObstacleHandler()
    {
        foreach (GameObject obstacle in Obstacles)
        {
        Debug.Log(obstacle.name);
            if (obstacle.name == "First Obstacle" && eyeCount == eyesInventory.Count && questsCompleted < 1)
            {
                obstacle.SetActive(true);
                eyesInventory.Clear();
                questsCompleted++;
            }
            else if (obstacle.name == "Second Obstacle" && ringCount == ringInventory.Count && questsCompleted < 2)
            {
                obstacle.SetActive(true);
                ringInventory.Clear();
                questsCompleted++;
            }
            else if (obstacle.name == "Third Obstacle" && bootsCount == bootsInventory.Count && questsCompleted < 3)
            {
                obstacle.SetActive(true);
                bootsInventory.Clear();
                questsCompleted++;
            }
        }
    }
    public void NPCAdvanceDialogue()
    {
        foreach (GameObject npc in NPCs)
        {
            switch (npc.name)
            {
                case "First NPC":
                    if (npc.GetComponent<InteractionObject>().HasNewDialogue = false && eyeCount == eyesInventory.Count && questsCompleted < 1)
                            npc.GetComponent<InteractionObject>().SecondCondition = true;
                    break;
                case "Second NPC":
                    if (npc.GetComponent<InteractionObject>().HasNewDialogue = false && ringCount == ringInventory.Count && questsCompleted < 2)
                            npc.GetComponent<InteractionObject>().SecondCondition = true;
                        break;
                case "Third NPC":
                    if (npc.GetComponent<InteractionObject>().HasNewDialogue = false && bootsCount == bootsInventory.Count && questsCompleted < 3)
                            npc.GetComponent<InteractionObject>().SecondCondition = true;
                    break;
                case "Fourth NPC":
                    if (npc.GetComponent<InteractionObject>().HasNewDialogue = false && helmetCount == helmetInventory.Count && questsCompleted < 4)
                            npc.GetComponent<InteractionObject>().SecondCondition = true;
                    break;
                default:
                    break;
            }
        }
    }

    public void UpdateItemsUI()
    {
        if (Inventory != null && eyesInventory.Count >= 0)
        {
            eyesSprite.SetActive(true);
            eyesUICount.text = eyesInventory.Count.ToString();
        }
        if (Inventory != null && ringInventory.Count >= 0)
        {
            ringSprite.SetActive(true);
            ringUICount.text = ringInventory.Count.ToString();
        }
        if (Inventory != null && bootsInventory.Count >= 0)
        {
            bootsSprite.SetActive(true);
            bootsUICount.text = bootsInventory.Count.ToString();
        }
        if (Inventory != null && ringInventory.Count >= 0)
        {
            ringSprite.SetActive(true);
            ringUICount.text = ringInventory.Count.ToString();
        }
        else return;
    }


    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log(ringInventory.Count);

        inventory = new();
        currentScene = scene;

        Obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        NPCs = GameObject.FindGameObjectsWithTag("NPC");

        if (scene.name == "GamePlay2")
        {
            eyesInventory = new();
            bootsInventory = new();
            ringInventory = new();
            helmetInventory = new();

            eyeObjects = GameObject.FindGameObjectsWithTag("Eye");
            bootsObjects = GameObject.FindGameObjectsWithTag("Boots");
            ringObjects = GameObject.FindGameObjectsWithTag("Ring");
            helmetObjects = GameObject.FindGameObjectsWithTag("Helmet");

            eyeCount = eyeObjects.Length;
            bootsCount = bootsObjects.Length;
            ringCount = ringObjects.Length;
            helmetCount = helmetObjects.Length;
        }

        if (scene.name != "GamePlay1" && scene.name != "Gameplay2" && scene.name != "Main Menu")
        {
            questsCompleted = 0;
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