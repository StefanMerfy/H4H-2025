using UnityEngine;

public class TriangleBehaviour : MonoBehaviour
{
    public Vector2 teleportPosition; // Set this in the Inspector
    public NewBehaviourScript playerMovement;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player")) // Ensure your player has the "Player" tag
        {
            //Destroy(collision.gameObject); // Destroy the player GameObject
            collision.transform.position = teleportPosition; // Teleport the player to the new position
        }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    }
}