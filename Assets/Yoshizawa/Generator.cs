using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 日本語対応
public class Generator : MonoBehaviour
{
    [SerializeField] private EnemyController[] _items = null;
    [SerializeField] private float _keepOutArea = 10f;
    [SerializeField] private float _generateArea = 5f;
    [SerializeField] private float _interval = 1f;
    private float _timer = 0f;

    private void Update()
    {
        Generate(Time.deltaTime);
    }

    public void Generate(float deltaTime)
    {
        _timer += deltaTime;

        if (_timer > _interval)
        {
            Vector2 vec = 
                (Random.insideUnitCircle - Vector2.zero).normalized *
                 Random.Range(_keepOutArea, _keepOutArea + _generateArea);
            vec.x = vec.x < 0 ? vec.x * -1 : vec.x;
            vec.y = vec.y < 0 ? vec.y * -1 : vec.y;
            Vector2 myPos = transform.position;
            int n = Random.Range(0, _items.Length);
            var enemy = Instantiate(_items[n], myPos + vec, Quaternion.identity, transform);
            enemy.Target = transform.position;
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
