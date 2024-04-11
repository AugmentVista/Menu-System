using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueBox : MonoBehaviour
{
    [SerializeField] private TMP_Text screenText;
    [SerializeField] private Image backgroundPanel;

    private Queue<string> textQueue = new Queue<string>();
    private InteractionObject currentObject;

    private const KeyCode advanceKey = KeyCode.E; // Define advance key

    private void Start()
    {
        if (screenText == null)
        {
            Debug.LogError("ScreenText component is not assigned.", this);
        }
        if (backgroundPanel == null)
        {
            Debug.LogError("BackgroundPanel component is not assigned.", this);
        }

        backgroundPanel.enabled = false;
    }

    private void Update()
    {
        if (QuestManager.isTalking && Input.GetKeyDown(advanceKey))
        {
            NextLine();
        }
    }

    public void SecondQueue(List<string> secondDialogue)
    {
        textQueue.Clear();
        foreach (string dialogueItem in secondDialogue)
        {
            textQueue.Enqueue(dialogueItem);
        }
        backgroundPanel.enabled = true;
        NextLine();
    }

    public void FillQueue(List<string> dialogue, InteractionObject interactionObj)
    {
        currentObject = interactionObj;
        textQueue.Clear();

        if (QuestManager.Thing2)
        {
            currentObject.ThirdToFirst();
        }
        else if (QuestManager.Thing3)
        {
            currentObject.SecondToFirst();
        }

        foreach (string dialogueItem in dialogue)
        {
            textQueue.Enqueue(dialogueItem);
        }
        backgroundPanel.enabled = true;
        QuestManager.isTalking = true;
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
        backgroundPanel.enabled = false;
    }
}
