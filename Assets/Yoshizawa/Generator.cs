using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 日本語対応
public class Generator : MonoBehaviour
{
    [Header("妖怪たちが攻撃する対象")]
    [SerializeField] private Transform _target = null;
    [Header("生成するオブジェクト")]
    [SerializeField] private EnemyController[] _items = null;
    [Header("生成禁止範囲")]
    [SerializeField] private float _keepOutArea = 10f;
    [Header("生成可能範囲")]
    [SerializeField] private float _generateArea = 5f;
    [Header("生成間隔")]
    [SerializeField] private float _interval = 1f;
    [Header("減少間隔")]
    [SerializeField] private float _reduceInterval = 1f;
    [Header("間隔を減少させる値")]
    [SerializeField] private float _reduceIntervalValue = 0.1f;
    private float _intervalTimer = 0f;
    private float _timer = 0f;

    private void Update()
    {
        if(!GameManager.Instance.IsPause) Generate(Time.deltaTime);
    }

    public void Generate(float deltaTime)
    {
        _intervalTimer += deltaTime;
        _timer += deltaTime;

        if (_intervalTimer > _interval)
        {
            Vector2 vec = 
                (Random.insideUnitCircle - Vector2.zero).normalized *
                 Random.Range(_keepOutArea, _keepOutArea + _generateArea);
            vec.y = vec.y < 0 ? vec.y * -1 : vec.y;
            Vector2 myPos = transform.position;
            int n = Random.Range(0, _items.Length);
            var enemy = Instantiate(_items[n], myPos + vec, Quaternion.identity, transform);
            if(_target) enemy.Target = _target.position;
            _intervalTimer = 0f;
        }

        if (_timer > _reduceInterval)
        {
            _interval -= _reduceIntervalValue;
            _timer = 0f;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _keepOutArea);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, _keepOutArea + _generateArea);
    }
}
