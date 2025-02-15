using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float speed = 0.2f; // Horizontal movement speed
    public float jumpForce = 9f; // Jump strength

    public float gravityScale = 1.5f;
    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = gravityScale;
    }

    void Update()
    {
        float move = 0f;

        if (Input.GetKey(KeyCode.A))
        {
            move = -0.5f; // Move left
        }
        else if (Input.GetKey(KeyCode.D))
        {
            move = 0.5f; // Move right
        }

        // Apply horizontal movement
        rb.linearVelocity = new Vector2(move * speed, rb.linearVelocity.y);

        // Jump when space is pressed & player is on the ground
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isGrounded = false; // Prevent double jumps
        }

        if (rb.linearVelocity.y == 0f) // When player is not falling or jumping
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, -1f); // Apply a tiny downward force to prevent sticking
        }
    }

    // Detect collisions to check if player is on the ground
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
