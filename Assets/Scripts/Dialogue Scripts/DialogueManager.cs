using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private TMP_Text screenText;
    [SerializeField] private Image DialogueBackgroundPanel;

    private Queue<string> textQueue = new Queue<string>();
    private InteractionObject currentObject;

    private const KeyCode nextDialogue = KeyCode.E; // "E" moves on to the next dialogue

    public bool isInDialogue;

    public void Startdialogue(List<string> dialogue, InteractionObject interactionObj)
    {
        if (DialogueBackgroundPanel == null)
        {
            DialogueBackgroundPanel = ReferenceManager.dialogueBackgroundPanelDependant;
        }
        isInDialogue = true;
        FillQueue(dialogue, interactionObj);
    }

    public void FillQueue(List<string> dialogue, InteractionObject interactionObj)
    {
        currentObject = interactionObj;
        textQueue.Clear();

        if (interactionObj.SecondCondition)
        {
            //currentObject.DialougeManager Second Dialogue
        }
        else if (interactionObj.ThirdCondition)
        {
            //currentObject.DialougeManager Third Dialogue
        }
        //else if (QuestManager.FourthCondition)  currentObject.DialougeManager Fourth Dialogue

        foreach (string dialogueItem in dialogue)
        {
            textQueue.Enqueue(dialogueItem);
        }
        DialogueBackgroundPanel.enabled = true;
        screenText.enabled = true;
        QuestManager.isTalking = true;
        NextLine();
    }

    private void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void Start()
    {
        if (screenText == null)
        {
            Debug.LogError("ScreenText component is not assigned.", this);
        }
        if (DialogueBackgroundPanel == null)
        {
            Debug.LogError("BackgroundPanel component is not assigned.", this);
        }

        DialogueBackgroundPanel.enabled = false;
        screenText.enabled = false;
    }

    private void Update()
    {
        if (QuestManager.isTalking && Input.GetKeyDown(nextDialogue))
        {
            NextLine();
        }
    }

    public void SecondQueue(List<string> secondDialogue)
    { 
        // Ensures that HasNewDialogue true only the first time per NPC
        for (int i = 0; i < 1; i++)
        {
            currentObject.GetComponent<InteractionObject>().HasNewDialogue = true;
        }

        textQueue.Clear();
        foreach (string dialogueItem in secondDialogue)
        {
            textQueue.Enqueue(dialogueItem);
        }
        DialogueBackgroundPanel.enabled = true;
        screenText.enabled = true;
        NextLine();
    }

    private void NextLine()
    {
        if (textQueue.Count > 0)
        {
            screenText.text = textQueue.Dequeue();
        }
        else if (textQueue.Count == 0)
        {
            ClearDialogue();
        }
    }

    private void ClearDialogue()
    {
        screenText.text = "";
        QuestManager.isTalking = false;
        if (DialogueBackgroundPanel == null)
        {
            DialogueBackgroundPanel = ReferenceManager.dialogueBackgroundPanelDependant;
        }
        DialogueBackgroundPanel.enabled = false;
        isInDialogue = false;
        currentObject.GetComponent<InteractionObject>().HasNewDialogue = false;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //ClearDialogue();
    }
}