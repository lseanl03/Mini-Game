using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    [SerializeField] private bool _isRun = false;
    [SerializeField] private float _directionX;
    [SerializeField] private float _jumpForce = 5f;
    [SerializeField] private Transform _shootPoint;

    private Coroutine _shootCoroutine;

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
        Attack();
    }
    private void Move()
    {
        _directionX = Input.GetAxisRaw("Horizontal");
        _rb2d.velocity = new Vector2(_directionX * _moveSpeed, _rb2d.velocity.y);

        var isRun = Mathf.Abs(_directionX) > 0.1f;

        if(!_animator.GetBool("isJump"))
        _animator.SetBool("isRun", isRun);

    }
    private void Jump()
    {
        if (!_isGround) return;

        bool isJump = Input.GetButtonDown("Jump");
        if (isJump)
        {
            _rb2d.AddForce(new Vector2(0f, _jumpForce), ForceMode2D.Impulse);
        }
    }
    private void Run()
    {
        _isRun = Input.GetKey(KeyCode.LeftShift) && Mathf.Abs(_directionX) > 0.1f;
        _animator.SetBool("isKickBoard", _isRun);

        if (_isRun) _rb2d.velocity = new Vector2(_rb2d.velocity.x * (_isRun ? 2 : 1), _rb2d.velocity.y);
    }

    private void Attack()
    {
        bool isAttack = Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0);
        if (isAttack)
        {
            if (_shootCoroutine != null) StopCoroutine(_shootCoroutine);
            _shootCoroutine = StartCoroutine(ShootCoroutine());
        }
    }


    protected override void Flip()
    {
        if (_directionX > 0 && !_isFacingRight || _directionX < 0 && _isFacingRight)
        {
            _isFacingRight = !_isFacingRight;
            Vector3 newScale = transform.localScale;
            newScale.x *= -1f;
            transform.localScale = newScale;
        }
    }


    private IEnumerator ShootCoroutine()
    {
        yield return new WaitForSeconds(0.1f);
        _animator.SetTrigger("attack");
        PlayerBullet bulletPrefab 
            = PoolManager.Instance.GetObject<PlayerBullet>(
            PoolType.Player_Bullet, _shootPoint.position, null);

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

    protected override void GroundEnter()
    {
        base.GroundEnter();
        _animator.SetBool("isJump", false);
    }

    protected override void GroundExit()
    {
        base.GroundExit();
        _animator.SetBool("isJump", true);
        if(_animator.GetBool("isRun"))
        {
            _animator.SetBool("isRun", false);
        }
    }
}
