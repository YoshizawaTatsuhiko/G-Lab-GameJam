using UnityEngine;

public class Firework : MonoBehaviour
{
    [SerializeField]
    private Firing _firing = new();
    [SerializeField]
    private int _attackValue = 1;

    private void Start()
    {
        _firing.Init(transform);
    }

    public void ShowFirework()
    {
        _firing.Explode(gameObject);
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
