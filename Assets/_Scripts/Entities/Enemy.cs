using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : Entity
{
    public Transform SpawnPos { get; private set; }
    [SerializeField] private float _patrolDistance = 5f;
    [SerializeField] private float _waitTime = 2f;
    [SerializeField] private float _waitCounter;

    private PatrolState _state = PatrolState.Patrol;

    public void GetData(Transform spawnPos, PoolType poolType)
    {
        SpawnPos = spawnPos;
        PoolType = poolType;
    }

    protected virtual void Update()
    {
        switch (_state)
        {
            case PatrolState.Patrol:
                Patrol();
                break;
            case PatrolState.Idle:
                IdlePatrol();
                break;
        }
    }

    private void Patrol()
    {
        if (!SpawnPos || !_isGround) return;

        var leftPoint = SpawnPos.position.x - _patrolDistance;
        var rightPoint = SpawnPos.position.x + _patrolDistance;
        _rb2d.velocity = new Vector2(_isFacingRight ? _moveSpeed : -_moveSpeed, _rb2d.velocity.y);
        _animator.SetBool("Run", true);

        if ((_isFacingRight && transform.position.x >= rightPoint) ||
            (!_isFacingRight && transform.position.x <= leftPoint))
        {
            _waitCounter = _waitTime;
            _state = PatrolState.Idle;
            _rb2d.velocity = new Vector2(0f, _rb2d.velocity.y);
            _animator.SetBool("Run", false);
        }
    }

    private void IdlePatrol()
    {
        _waitCounter -= Time.deltaTime;
        if (_waitCounter <= 0)
        {
            Flip();
            _state = PatrolState.Patrol;                    
        }
    }
}
