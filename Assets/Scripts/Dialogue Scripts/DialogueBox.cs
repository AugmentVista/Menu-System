using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueBox : MonoBehaviour
{
    [SerializeField] private TMP_Text screenText;
    [SerializeField] private Image DialogueBackgroundPanel;

    private Queue<string> textQueue = new Queue<string>();
    private InteractionObject currentObject;

    private const KeyCode nextDialogue = KeyCode.E; // "E" moves on to the next dialogue

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

    public void FillQueue(List<string> dialogue, InteractionObject interactionObj)
    {
        currentObject = interactionObj;
        textQueue.Clear();

        if (QuestManager.SecondCondition)
        {
            //currentObject.DialougeManager Second Dialogue
        }
        else if (QuestManager.ThirdCondition)
        {
            //currentObject.DialougeManager Third Dialogue
        }
        //else if (QuestManager.FourthCondition)  currentObject.DialougeManager Fourth Dialogue

        foreach (string dialogueItem in dialogue)
        {
            textQueue.Enqueue(dialogueItem);
        }
        DialogueBackgroundPanel.enabled = true;
        QuestManager.isTalking = true;
        NextLine();
    }
    public void SecondQueue(List<string> secondDialogue)
    {
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
        DialogueBackgroundPanel.enabled = false;
    }
}