using DG.Tweening;
using UnityEngine;

public class Firework : MonoBehaviour
{
    [SerializeField]
    private Firing _firing = new();
    [SerializeField]
    private LifeManager _lifeManager = default;
    [SerializeField]
    private int _attackValue = 1;

    private SpriteRenderer _renderer = default;

    private void Start()
    {
        _firing.Init(transform);
        _renderer = GetComponent<SpriteRenderer>();
    }

    public void ShowFirework(int scale)
    {
        _renderer.transform.localScale = Vector3.zero;
        _renderer.transform.DOScale(Vector3.one * scale, 1.5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out EnemyController enemy))
        {
            enemy.gameObject.TryGetComponent(out LifeManager life);
            life.ReduceLife(_attackValue);
        }
    }
}
