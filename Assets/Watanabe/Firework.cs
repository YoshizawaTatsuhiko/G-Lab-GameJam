using DG.Tweening;
using UnityEngine;

public class Firework : MonoBehaviour
{
    [SerializeField]
    private Firing _firing = new();
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

        var sequence = DOTween.Sequence();
        sequence
            .Append(_renderer.transform.DOScale(Vector3.one * scale, 1.5f))
            .AppendCallback(() =>
            {
                _renderer.enabled = false;
                _renderer.transform.localScale = Vector3.one;
            })
            .AppendInterval(1f)
            .OnComplete(() =>
            {
                _renderer.enabled = true;
            });

        _firing.Explode();
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
