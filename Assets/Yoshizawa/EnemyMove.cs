using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
// 日本語対応
public class EnemyMove : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 1f;
    private Rigidbody2D _rb2d = null;

    private void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _rb2d.gravityScale = 0f;
    }

    private void Update()
    {
        _rb2d.velocity = (Vector2.zero - _rb2d.position).normalized * _moveSpeed;
    }
}
