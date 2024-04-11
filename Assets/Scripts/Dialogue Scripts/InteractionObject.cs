using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractionObject : MonoBehaviour
{
    public enum Types
    {
        nothing, pickup, info, dialogue,
    }
    public Types type;

    public string infoText;
    public TMP_Text DialogueTMP;
    public string DialogueText;
    public TMP_Text InfoTMP;
    public string InfoText;
    public List<string> Dialogue;
    public List<string> SecondDialogue;
    public List<string> ThirdDialogue;
    Info info;
    DialogueBox dialogueBox;
    void Start()
    {
        info = FindObjectOfType<Info>();
        dialogueBox = FindObjectOfType<DialogueBox>();
    }
    public void Interact()
    {
        switch (type)
        {
            case Types.nothing:
                Nothing();
                break;
            case Types.pickup:
                Pickup();
                break;
            case Types.info:
                Info();
                break;
            case Types.dialogue:
                FirstDialogue();
                break;
        }
    }
    void Nothing()
    {
        Debug.Log("Empty");
    }
    void Pickup()
    {
        Debug.Log("Pickup");
        gameObject.SetActive(false);

    }
    void Info()
    {
        Debug.Log("Info Display");
        info.SetText(infoText);
    }
    void FirstDialogue()
    {
        Debug.Log("Dialogue registering");
        dialogueBox.FillQueue(Dialogue, this);
    }
    public void SecondToFirst()
    {
        Dialogue.Clear();
        foreach (string line in SecondDialogue)
        {
            Dialogue.Add(line);
        }
    }
    public void ThirdToFirst()
    {
        Dialogue.Clear();
        foreach (string line in ThirdDialogue)
        {
            Dialogue.Add(line);
        }
    }
}