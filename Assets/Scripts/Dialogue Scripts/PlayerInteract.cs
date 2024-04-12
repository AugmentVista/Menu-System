using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField]
    GameObject CurrentObject;
    void Update()
    {
        if (!QuestManager.isTalking && Input.GetKeyDown("space"))
        {
            PlayerInteraction();
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<InteractionObject>() == true)
        {
            CurrentObject = collision.gameObject;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<InteractionObject>() == true)
        {
            CurrentObject = null;
        }
    }
    public void PlayerInteraction()
    {
        //Debug.Log(CurrentObject.name);
        if (CurrentObject != null)
            CurrentObject.GetComponent<InteractionObject>().Interact();
    }
}