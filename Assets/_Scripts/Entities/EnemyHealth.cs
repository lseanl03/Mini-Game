using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : EntityHealth
{
    private Enemy _enemy;

    protected override void Awake()
    {
        base.Awake();
        if (!_enemy) _enemy = GetComponent<Enemy>();
    }
    protected override void Die()
    {
        GameManager.Instance.EnemyKilled++;
        EventManager.OnEnemyDied?.Invoke();
        PoolManager.Instance.ReturnObject(_enemy.PoolType, gameObject);
    }
}
