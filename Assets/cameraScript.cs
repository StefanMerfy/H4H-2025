using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed = 5f; // Adjust to make movement smoother

    void Update()
    {
        Vector3 targetPosition = new Vector3(player.position.x, player.position.y+0.5f, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
        

        // Set camera position to smoothed position
        //transform.position = smoothedPosition;
    }
}
