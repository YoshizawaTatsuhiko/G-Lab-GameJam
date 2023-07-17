using UnityEngine;

public class Firework : MonoBehaviour
{
    [SerializeField]
    private Firing _firing = new();

    private int _attackValue = 1;
    private CircleCollider2D _circleCollider = default;

    private void Start()
    {
        _firing.Init(transform);
        _circleCollider = GetComponent<CircleCollider2D>();
    }

    public void ShowFirework(float radius)
    {
        _firing.Explode(gameObject, radius);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out EnemyController enemy))
        {
            enemy.gameObject.TryGetComponent(out LifeManager life);

            if (_circleCollider.radius <= 1)
            {
                _attackValue = 2;
            }
            else if (_circleCollider.radius <= 2)
            {
                _attackValue = 4;
            }
            else if (_circleCollider.radius <= 3)
            {
                _attackValue = 5;
            }
            else if (_circleCollider.radius <= 4)
            {
                _attackValue = 6;
            }
            else
            {
                _attackValue = 10;
            }
            life.ReduceLife(_attackValue);
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, _circleCollider.radius);
    }
#endif
}
