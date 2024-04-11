using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> dialogueQueue = new Queue<string>();

    public void StartFirstDialogue(List<string> dialogue)
    {
        dialogueQueue.Clear();
        foreach (string line in dialogue)
        {
            dialogueQueue.Enqueue(line);
        }
    }

    // Transition from another dialogue to the first dialogue sequence
    public void TransitionToFirstDialogue(List<string> newDialogue)
    {
        dialogueQueue.Clear();
        foreach (string line in newDialogue)
        {
            dialogueQueue.Enqueue(line);
        }
        // Additional logic for transitioning to the first dialogue, if needed
    }

    public void TransitionDialogue(List<string> fromDialogue, List<string> toDialogue)
    {
        toDialogue.Clear();
        foreach (string line in fromDialogue)
        {
            toDialogue.Add(line);
        }
    }
}
