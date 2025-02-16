using UnityEngine;

public class PlatformCamera : MonoBehaviour
{
    private bool shouldFollow = true;
    public Transform player;
    public float smoothSpeed = 5f;
    public float verticalOffset = 0.5f;

    void Update()
    {
        if (shouldFollow)
        {
            Vector3 targetPosition = new Vector3(player.position.x, player.position.y + verticalOffset, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
        }
    }

    public void StopFollowing()
    {
        shouldFollow = false;
    }

    public void StartFollowing()
    {
        shouldFollow = true;
    }
}