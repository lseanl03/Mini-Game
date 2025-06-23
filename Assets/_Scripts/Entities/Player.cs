using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private bool isGrounded; 
    [SerializeField] private float speed = 5f; 
    [SerializeField] private float jumpForce = 5f;
    
    private Rigidbody2D rb2d; 
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>(); 
    }
    private void Update()
    {
        InputHandle();
    }
    private void InputHandle()
    {
        Move();
        Jump();
        Run();
    }
    private void Move()
    {
        float moveInput = Input.GetAxisRaw("Horizontal"); 
        rb2d.velocity = new Vector2(moveInput * speed, rb2d.velocity.y); 
    }
    private void Jump()
    {
        if (isGrounded && Input.GetButtonDown("Jump")) 
        {
            rb2d.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse); 
            isGrounded = false; 
        }
    }
    private void Run()
    {
        if (Input.GetKey(KeyCode.LeftShift)) 
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x * 2, rb2d.velocity.y); 
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) 
        {
            isGrounded = true; 
        }
    }
}
