using UnityEngine;

public class Firing : MonoBehaviour
{
    [SerializeField]
    private int _attackValue = 1;

    private Animator _anim = default;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    #region called by AnimationEvent
    public void SEPlay()
    {
        TryGetComponent(out AudioPlayer audio);
        audio.PlaySE(Random.Range(0, audio.FireworkSE.Length));
    }

    public void VanishFirework()
    {
        Destroy(gameObject, 1f);
    }
    #endregion

    public bool PlayAnimation()
    {
        return _anim.GetCurrentAnimatorStateInfo(0).IsName("Bomb");
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
