using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f; // Speed of the player movement
    public float jumpForce = 5f; // Force applied when jumping
    private Rigidbody2D rb; // Reference to the Rigidbody2D component
    private bool isGrounded; // Check if the player is on the ground
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component
    }
    void Update()
    {
        Move(); // Call the move function
        Jump(); // Call the jump function
    }
    void Move()
    {
        float moveInput = Input.GetAxis("Horizontal"); // Get horizontal input
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y); // Set velocity based on input
    }
    void Jump()
    {
        if (isGrounded && Input.GetButtonDown("Jump")) // Check if grounded and jump button pressed
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse); // Apply jump force
            isGrounded = false; // Set grounded to false after jumping
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // Check if collided with ground
        {
            isGrounded = true; // Set grounded to true
        }
    }
}
