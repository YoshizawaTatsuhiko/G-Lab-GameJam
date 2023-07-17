using UnityEngine;

public class FireworkController : MonoBehaviour
{
    [Tooltip("調整値")]
    [Range(0.01f, 0.1f)]
    [SerializeField]
    private float _adjustedValue = 1f;
    [SerializeField]
    private float _maxScaleValue = 5f;
    [SerializeField]
    private GameObject _fireworkPrefab = default;

    private GameObject _firework = default;
    private CircleCollider2D _circleCollider = default;
    private float _moveValue = 1f;
    private float _radius = 1f;
    private bool _isInflate = false;

    private void Start()
    {
        _firework = Instantiate(_fireworkPrefab, transform.position, Quaternion.identity);
        _circleCollider = _firework.GetComponent<CircleCollider2D>();
        _radius = _circleCollider.radius;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //計測開始
            Debug.Log("計測開始");
            _circleCollider.enabled = false;
            _moveValue = 1f;
        }
        else if (Input.GetMouseButton(0))
        {
            if (_isInflate) return;

            //計測中
            _moveValue += (Mathf.Abs(Input.GetAxis("Mouse X")) + Mathf.Abs(Input.GetAxis("Mouse Y"))) * _adjustedValue;
            _firework.transform.localScale = Vector3.one * _moveValue;
            _circleCollider.radius += _moveValue * 0.001f;

            if (_firework.transform.localScale.x >= _maxScaleValue)
            {
                _isInflate = true;
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            //爆発
            Debug.Log("Bomb!!");
            _circleCollider.enabled = true;
            _isInflate = false;
            Explosion();
            _circleCollider.radius = _radius;
        }
    }

    private void Explosion()
    {
        _firework.GetComponent<Firework>().ShowFirework(_circleCollider.radius);
    }
}
