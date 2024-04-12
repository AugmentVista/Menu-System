using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class InteractionObject : MonoBehaviour
{
    private Info info;
    private TMP_Text dialogueTMP;
    private DialogueManager dialogueManager;
    private string dialogueText;
    public string infoText;
    private QuestManager questManager;
    [SerializeField] private SpriteRenderer renderer; // pickup only
    [SerializeField] private BoxCollider2D collider; // pickup only

    public bool SecondCondition = false;
    public bool ThirdCondition = false;

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
    public int pickupCount;
    public enum Pickups
    {
        Coin, Eyes, Boots
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
            case Pickups.Coin:
                questManager.coinInventory.Add(pickupType);
                break;
            case Pickups.Eyes:
                questManager.eyesInventory.Add(pickupType);
                break;
            case Pickups.Boots:
                questManager.bootsInventory.Add(pickupType);
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