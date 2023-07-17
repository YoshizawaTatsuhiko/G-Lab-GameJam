using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 日本語対応
public class LifeManager : MonoBehaviour
{
    public int Life => _life;

    [SerializeField, Range(1, 10)] private int _life = 1;

    public void ReduceLife(int damage)
    {
        _life -= damage;

        if (_life <= 0) Destroy(gameObject);
    }
}
