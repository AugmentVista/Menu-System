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
    public GameObject Water;

    public TextMeshProUGUI eyesUICount; 
    public TextMeshProUGUI ringUICount;
    public TextMeshProUGUI bootsUICount;
    public TextMeshProUGUI helmetUICount;

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
            Debug.Log(bootsCount);
            Debug.Log(bootsInventory.Count);
            if (obstacle.name == "First Obstacle" && eyeCount == eyesInventory.Count )
            {
                obstacle.SetActive(true);
                questsCompleted++;
                NPCAdvanceDialogue();
                eyesInventory.Clear();
            }
            else if (obstacle.name == "Second Obstacle" && bootsCount == bootsInventory.Count )
            {
                obstacle.SetActive(false);
                questsCompleted++;
                NPCAdvanceDialogue();
                bootsInventory.Clear();
            }
            else if (obstacle.name == "Third Obstacle" && ringCount == ringInventory.Count )
            {
                obstacle.SetActive(true);
                questsCompleted++;
                NPCAdvanceDialogue();
                ringInventory.Clear();
            }
            else if (obstacle.name == "Fourth Obstacle" && helmetCount == helmetInventory.Count)
            {
                obstacle.SetActive(true);
                questsCompleted++;
                NPCAdvanceDialogue();
                helmetInventory.Clear();
            }
            else if (obstacle.name == "Fourth Obstacle" && !Water.activeSelf && obstacle.activeSelf)
            {
                questsCompleted++;
                NPCAdvanceDialogue();
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
                    if (npc.GetComponent<InteractionObject>().HasNewDialogue == false && eyeCount == eyesInventory.Count )
                        npc.GetComponent<InteractionObject>().SecondCondition = true;
                    break;
                case "Second NPC":
                    if (npc.GetComponent<InteractionObject>().HasNewDialogue == false && bootsCount == bootsInventory.Count )
                        npc.GetComponent<InteractionObject>().SecondCondition = true;
                    break;
                case "Third NPC":
                    if (npc.GetComponent<InteractionObject>().HasNewDialogue == false && ringCount == ringInventory.Count )
                        npc.GetComponent<InteractionObject>().SecondCondition = true;
                    break;
                case "Fourth NPC":
                    if (npc.GetComponent<InteractionObject>().HasNewDialogue == false && helmetCount == helmetInventory.Count )
                        npc.GetComponent<InteractionObject>().SecondCondition = true;
                    break;
                case "Fifth NPC":
                    Debug.Log(Water.activeSelf);
                    if (!Water.activeSelf)
                    {
                        npc.GetComponent<InteractionObject>().SecondCondition = true && !Water.activeSelf;
                        npc.GetComponent<BoxCollider2D>().enabled = false;
                        npc.GetComponent<InteractionObject>().isFading = true;
                    }
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

        if (Inventory != null && helmetInventory.Count >= 0)
        {
            helmetSprite.SetActive(true);
            helmetUICount.text = helmetInventory.Count.ToString();
        }

        else return;
    }


    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

        inventory = new();
        currentScene = scene;

        Obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        NPCs = GameObject.FindGameObjectsWithTag("NPC");

        eyesInventory = new();
        bootsInventory = new();
        ringInventory = new();
        helmetInventory = new();

        if (scene.name == "GamePlay2")
        {
            Water = GameObject.FindWithTag("Water");
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
                if (obstacle.name == "First Obstacle" || obstacle.name == "Third Obstacle" || obstacle.name == "Fourth Obstacle")
                    obstacle.SetActive(false);
            }
        }
    }
}