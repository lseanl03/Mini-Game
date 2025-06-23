using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    [SerializeField] private float directionX;
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
        Flip();
    }
    private void Move()
    {
        directionX = Input.GetAxisRaw("Horizontal");
        _rb2d.velocity = new Vector2(directionX * speed, _rb2d.velocity.y);

        var isRun = directionX > 0.1f || directionX < -0.1f;
        _animator.SetBool("isRun", isRun);

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

    protected override void Flip()
    {
        if (directionX > 0 && !_isFacingRight || directionX < 0 && _isFacingRight)
        {
            _isFacingRight = !_isFacingRight;
            Vector3 newScale = transform.localScale;
            newScale.x *= -1f;
            transform.localScale = newScale;
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
