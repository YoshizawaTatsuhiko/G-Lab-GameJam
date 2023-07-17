using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 日本語対応
public class Generator : MonoBehaviour
{
    [SerializeField] private GameObject[] _items = null;
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
            int n = Random.Range(0, _items.Length);
            Instantiate(_items[n], vec, Quaternion.identity, transform);
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
