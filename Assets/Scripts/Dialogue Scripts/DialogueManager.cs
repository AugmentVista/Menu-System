using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> dialogueQueue = new Queue<string>();

    // Start the first dialogue sequence
    public void StartFirstDialogue(List<string> dialogue)
    {
        dialogueQueue.Clear();
        foreach (string line in dialogue)
        {
            dialogueQueue.Enqueue(line);
        }
        // Additional logic to start displaying dialogue, if needed
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

    // Method to transition dialogue from another list to the first list
    public void TransitionDialogue(List<string> fromDialogue, List<string> toDialogue)
    {
        toDialogue.Clear();
        foreach (string line in fromDialogue)
        {
            toDialogue.Add(line);
        }
    }
}
