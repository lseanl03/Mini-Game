using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityHealth : MonoBehaviour
{
    [SerializeField] public int _maxHealth;
    [SerializeField] public int _currentHealth;

    protected virtual void Awake() { }
    public virtual void Init(int maxHeath)
    {
        _maxHealth = maxHeath;
        _currentHealth = maxHeath;
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
