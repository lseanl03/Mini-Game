using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 5f;

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
        _rb2d.velocity = new Vector2(moveInput * speed, _rb2d.velocity.y);
    }
    private void Jump()
    {
        if (_isGround && Input.GetButtonDown("Jump"))
        {
            _rb2d.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }
    private void Run()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _rb2d.velocity = new Vector2(_rb2d.velocity.x * 2, _rb2d.velocity.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("NPC"))
        {
            EventManager.OnNPCCollisionEnter?.Invoke();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("NPC"))
        {
            EventManager.OnNPCCollisionExit?.Invoke();
        }
    }

}
