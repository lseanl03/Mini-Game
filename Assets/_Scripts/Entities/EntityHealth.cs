using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityHealth : MonoBehaviour
{
    [SerializeField] public int _maxHealth = 10;
    [SerializeField] public int _currentHealth;
    protected virtual void Awake()
    {
        _currentHealth = _maxHealth;
    }
    public virtual void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        if (_currentHealth <= 0)
        {
            Die();
        }
    }
    protected virtual void Die() { }
}
