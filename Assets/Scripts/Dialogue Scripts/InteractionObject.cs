using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractionObject : MonoBehaviour
{
    private Info info;
    private DialogueManager dialogueManager;
    private QuestManager questManager;
    private TMP_Text dialogueTMP;
    private string dialogueText;
    public string infoText;

    public bool SecondCondition = false;
    public bool ThirdCondition = false;
    public bool HasNewDialogue = true;

    void Start()
    {
        info = ReferenceManager.infoDependant;
        dialogueTMP = ReferenceManager.dialogueTextDependant;
        dialogueText = ReferenceManager.dialogueTextDependant.text;
        dialogueManager = ReferenceManager.dialogueManagerDependant;
        questManager = Singleton.instance.GetComponentInChildren<QuestManager>();
    }

    public enum Types
    {
        nothing, pickup, info, dialogue,
    }
    public Types type;

    public List<string> firstDialogue;
    public List<string> secondDialogue;
    public List<string> thirdDialogue;

    public Pickups pickupType;
    public enum Pickups
    {
        Ring, Eyes, Boots, Helmet
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
            if (ThirdCondition)
            {
                dialogueManager.Startdialogue(thirdDialogue, this);
            }
            else if (SecondCondition)
            { 
                dialogueManager.Startdialogue(secondDialogue, this);
            }
            else
            {
                dialogueManager.Startdialogue(firstDialogue, this);
            }
            break;
        }
        if (!HasNewDialogue)
            questManager.ProgressCheck();
    }
    void Nothing()
    {
        Debug.Log("Empty");
    }

    void Pickup()
    {
        Debug.Log("Pickup");
        questManager.inventory.Add(pickupType);
        Debug.Log(questManager.inventory.Count);

        switch (pickupType)
        {
            case Pickups.Ring:
                questManager.ringInventory.Add(pickupType);
                break;
            case Pickups.Eyes:
                questManager.eyesInventory.Add(pickupType);
                break;
            case Pickups.Boots:
                questManager.bootsInventory.Add(pickupType);
                break;
            case Pickups.Helmet:
                questManager.helmetInventory.Add(pickupType);
                break;
            default:
                break;
        }
        gameObject.SetActive(false);
    }
    void Info()
    {
        Debug.Log("Info Display");
        info.ShowInfo(infoText);
    }
}