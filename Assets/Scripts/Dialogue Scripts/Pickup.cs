using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] private SpriteRenderer renderer;
    [SerializeField] private BoxCollider2D collider;

    public enum Pickups
    {
        Coin, Plant, Boots
    }
    public Pickups pickupType;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            renderer.enabled = false;
            collider.enabled = false;

            // Handle pickup based on type
            switch (pickupType)
            {
                case Pickups.Coin:
                    // Handle coin pickup
                    break;
                case Pickups.Plant:
                    // Handle plant pickup
                    break;
                case Pickups.Boots:
                    // Handle boots pickup
                    break;
                default:
                    break;
            }
        }
    }
}

