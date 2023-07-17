using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
// 日本語対応
public class EnemyController : MonoBehaviour
{
    public Vector2 Target { get; set; } = Vector2.zero;

    [SerializeField] private float _moveSpeed = 1f;
    [SerializeField] private int _damage = 1;
    private Rigidbody2D _rb2d = null;

    private void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _rb2d.gravityScale = 0f;
    }

    private void Update()
    {
        _rb2d.velocity = (Target - _rb2d.position).normalized * _moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Firework firework))
        {
            if(firework.gameObject.TryGetComponent(out LifeManager life))
            {
                life.ReduceLife(_damage);
            }
        }
    }
}
