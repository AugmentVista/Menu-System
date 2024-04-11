using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractionObject : MonoBehaviour
{
    private Info info;
    private DialogueBox dialogueBox;
    private TMP_Text dialogueTMP;
    private DialogueManager dialogueManager;
    private string dialogueText;
    public string infoText;
    void Start()
    {
        info = ReferenceManager.infoDependant;
        dialogueBox = ReferenceManager.dialogueBoxDependant;
        dialogueTMP = ReferenceManager.dialogueTextDependant;
        dialogueText = ReferenceManager.dialogueTextDependant.text;
        dialogueManager = ReferenceManager.dialogueManagerDependant;
    }

    public enum Types
    {
        nothing, pickup, info, dialogue,
    }
    public Types type;

    public List<string> Dialogue;
    public List<string> SecondDialogue;
    public List<string> ThirdDialogue;
    
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
                dialogueManager.StartFirstDialogue(Dialogue);
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
        info.ShowInfo(infoText);
    }
}