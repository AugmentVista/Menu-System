using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField]
    GameObject CurrentObject;
    void Update()
    {
        if (!QuestManager.isTalking && Input.GetKeyDown("space"))
        {
            playerInteract();
        }
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer < 15) // change layer to tags
        {
            CurrentObject = collision.gameObject;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer < 15) // change layer to tags
        {
            CurrentObject = null;
        }
    }
    public void playerInteract()
    {
        if (CurrentObject != null)
            CurrentObject.GetComponent<InteractionObject>().Interact();
    }
}