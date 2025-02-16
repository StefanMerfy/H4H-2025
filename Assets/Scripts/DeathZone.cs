using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public Transform checkpointPosition;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.position = checkpointPosition.position;
        }
    }
}