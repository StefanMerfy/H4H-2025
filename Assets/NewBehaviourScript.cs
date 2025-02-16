using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float speed = 0.2f; // Horizontal movement speed
    public float jumpForce = 100f; // Jump strength (adjust this to a lower value for slower jumps)
    public float gravityScale = 0f; // Gravity scale for falling speed (adjust this as needed)

    private Rigidbody2D rb;
    private bool isGrounded;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb.gravityScale = gravityScale; // Set gravity scale
    }

    void Update()
    {
        float move = 0f;

        // Horizontal movement
        if (Input.GetKey(KeyCode.A))
        {
            move = -0.2f;
            spriteRenderer.flipX = true; // Move left
        }
        else if (Input.GetKey(KeyCode.D))
        {
            move = 0.2f;
            spriteRenderer.flipX = false; // Move right
        }

        // Apply horizontal movement
        rb.linearVelocity = new Vector2(move * speed, rb.linearVelocity.y);

        // Jump when space is pressed & player is on the ground
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce); // Apply jump force
            isGrounded = false; // Prevent double jumps
        }
    }

    // Detect collisions to check if player is on the ground
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; // Allow jumping again when touching the ground
        }
    }
}
