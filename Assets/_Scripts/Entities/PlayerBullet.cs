using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private int damage = 10;
    private float speed = 15;
    private float lifeTime = 5;
    private Rigidbody2D _rb2d;
    private Coroutine _lifeTimeCoroutine;
    private void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        _rb2d.velocity = transform.right * speed;
        if (_lifeTimeCoroutine != null) StopCoroutine(_lifeTimeCoroutine);
        _lifeTimeCoroutine = StartCoroutine(LifeTimeCoroutine());
    }

    private IEnumerator LifeTimeCoroutine()
    {
        yield return new WaitForSeconds(lifeTime);
        PoolManager.Instance.ReturnObject(PoolType.Player_Bullet, gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            var health = collision.GetComponent<EntityHealth>();
            if (!health) return;
            
            health.TakeDamage(damage);
            PoolManager.Instance.ReturnObject(PoolType.Player_Bullet, gameObject);
        }
    }
}
