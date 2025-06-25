using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public PoolType PoolType{ get; protected set; }
    [SerializeField] protected bool _isGround = false;
    [SerializeField] protected bool _canMove = true;
    [SerializeField] protected bool _isFacingRight = true;
    [SerializeField] protected float _moveSpeed = 10;

    protected Rigidbody2D _rb2d;
    protected Collider2D _collider2D;
    protected Animator _animator;
    protected EntityHealth _entityHealth;

    protected virtual void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _collider2D = GetComponent<Collider2D>();
        _animator = GetComponentInChildren<Animator>();
        _entityHealth = GetComponent<EntityHealth>();
    }

    protected virtual void Flip()
    {
        _isFacingRight = !_isFacingRight;
        Vector3 newScale = transform.localScale;
        newScale.x *= -1f;
        transform.localScale = newScale;
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            GroundEnter();
        }
    }
    protected virtual void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            GroundExit();
        }
    }

    protected virtual void GroundEnter()
    {
        _isGround = true;
    }
    protected virtual void GroundExit()
    {
        _isGround = false;
    }
}
