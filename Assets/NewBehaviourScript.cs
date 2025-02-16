using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float speed = 3f; // Horizontal movement speed
    public float jumpForce = 9f; // Jump strength

    public float gravityScale = 2f;

    private Rigidbody2D rb;
    private bool isGrounded;
    
    private bool facingRight = true;

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
            move = -1f; // Move left
        }
        else if (Input.GetKey(KeyCode.D))
        {
            move = 1f; // Move right
        }

        // Apply horizontal movement
        rb.velocity = new Vector2(move * speed, rb.velocity.y); // Fixed property name

        // Flip the player sprite based on movement direction
        if (move > 0 && !facingRight)
        {
            Flip();
        }
        else if (move < 0 && facingRight)
        {
            Flip();
        }

        // Jump when space is pressed & player is on the ground
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); // Fixed property name
            isGrounded = false; // Prevent double jumps
        }

    }

    private void Flip()
    {
        facingRight = !facingRight; // Toggle direction
        Vector3 scale = transform.localScale;
        scale.x *= -1; // Flip the sprite
        transform.localScale = scale;
    }

    // Detect collisions to check if player is on the ground
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    // Detect when player leaves the ground
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }



}
