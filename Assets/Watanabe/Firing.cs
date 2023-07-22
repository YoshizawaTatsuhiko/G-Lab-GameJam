using UnityEngine;

public class Firing : MonoBehaviour
{
    [SerializeField]
    private int _attackValue = 1;

    private Animator _anim = default;
    private AudioPlayer _audio = default;

    private void Awake()
    {
        TryGetComponent(out Animator _anim);
        TryGetComponent(out AudioPlayer _audio);
    }

    private void Start()
    {
        _audio.PlaySE(0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out EnemyController enemy))
        {
            enemy.gameObject.TryGetComponent(out LifeManager life);
            var collider = GetComponent<CircleCollider2D>();

            if (collider.radius <= 1)
            {
                _attackValue = 2;
            }
            else if (collider.radius <= 2)
            {
                _attackValue = 4;
            }
            else if (collider.radius <= 3)
            {
                _attackValue = 5;
            }
            else if (collider.radius <= 4)
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
        Gizmos.DrawWireSphere(transform.position, GetComponent<CircleCollider2D>().radius);
    }
#endif
}
