using UnityEngine;
using UnityEngine.SceneManagement;

public class Platform : MonoBehaviour
{
    public Transform posA, posB;
    public float speed = 5f;
    private bool hasTriggered = false;
    private bool isReturning = false;
    private PlatformCamera platformCamera;
    private bool hasLoadedLevel = false;

    void Start()
    {
        if (posA == null || posB == null)
        {
            enabled = false;
            return;
        }
        transform.position = posA.position;
        platformCamera = Camera.main.GetComponent<PlatformCamera>();
    }

    void Update()
    {
        if (hasTriggered && !isReturning)
        {
            float distance = Vector2.Distance(transform.position, posB.position);
            if (distance > 0.1f)
            {
                Vector2 newPosition = Vector2.MoveTowards(transform.position, posB.position, speed * Time.deltaTime);
                transform.position = newPosition;
            }
            else if (!hasLoadedLevel)
            {
                hasLoadedLevel = true;
                SceneManager.LoadScene("Level3");
            }
        }
        
        if (isReturning)
        {
            float distance = Vector2.Distance(transform.position, posA.position);
            if (distance > 0.1f)
            {
                Vector2 newPosition = Vector2.MoveTowards(transform.position, posA.position, speed * Time.deltaTime);
                transform.position = newPosition;
            }
            else
            {
                isReturning = false;
                hasTriggered = false;
                hasLoadedLevel = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !hasTriggered)
        {
            hasTriggered = true;
            isReturning = false;
            collision.transform.SetParent(transform);
            
            if (platformCamera != null)
            {
                platformCamera.StopFollowing();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
            isReturning = true;
            
            if (platformCamera != null)
            {
                platformCamera.StartFollowing();
            }
        }
    }
}