using UnityEngine;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReferenceManager : MonoBehaviour
{
    // List to keep track of objects that depend on the ReferenceManager
    private List<GameObject> dependentObjects = new List<GameObject>();

    [SerializeField] private DialogueManager dialogueManager;
    [SerializeField] private QuestManager questManager;
    [SerializeField] private Info info;
    [SerializeField] private GameObject player;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private TMP_Text infoText;
    [SerializeField] private Image dialogueBackgroundPanel;
    [SerializeField] private Image infoBackgroundPanel;
    [SerializeField] private Queue<string> dialogueQueue;

    // Static fields to hold references to the dependencies
    public static DialogueManager dialogueManagerDependant;
    public static QuestManager questManagerDependant;
    public static Info infoDependant;
    public static GameObject playerDependant;
    public static Transform playerTransformDependant;
    public static TMP_Text dialogueTextDependant;
    public static TMP_Text infoTextDependant;
    public static Image dialogueBackgroundPanelDependant;
    public static Image infoBackgroundPanelDependant;
    public static Queue<string> dialogueQueueDependant;

    private void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void Start()
    {
        AssignStaticReferences();
    }

    private void AssignStaticReferences()
    {
        dialogueManagerDependant = dialogueManager;
        questManagerDependant = questManager;
        infoDependant = info;
        playerDependant = player;
        playerTransformDependant = playerTransform;
        dialogueTextDependant = dialogueText;
        infoTextDependant = infoText;
        dialogueBackgroundPanelDependant = dialogueBackgroundPanel;
        infoBackgroundPanelDependant = infoBackgroundPanel;
        dialogueQueueDependant = dialogueQueue;
    }

    // Method for objects to register themselves as dependent on the ReferenceManager
    public void RegisterDependentObject(GameObject obj)
    {
        dependentObjects.Add(obj);
    }

    public void DestroyDependentObjects()
    {
        foreach (GameObject obj in dependentObjects)
        {
            Destroy(obj);
        }

        // Clear the list of dependent objects
        dependentObjects.Clear();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (mode == LoadSceneMode.Single)
        {
        }
    }
}