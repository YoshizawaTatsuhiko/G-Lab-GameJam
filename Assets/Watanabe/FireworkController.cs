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

    private float _moveValue = 1f;
    private bool _isInflate = false;
    private SpriteRenderer _renderer = default;

    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        SettingDefault();
    }

    private void SettingDefault()
    {
        _renderer.enabled = true;
        transform.localScale = Vector3.one;
        _moveValue = 1f;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //計測開始
            Debug.Log("計測開始");
            SettingDefault();
        }
        else if (Input.GetMouseButton(0))
        {
            if (_isInflate) return;

            //計測中
            _moveValue += (Mathf.Abs(Input.GetAxis("Mouse X")) + Mathf.Abs(Input.GetAxis("Mouse Y"))) * _adjustedValue;
            transform.localScale = Vector3.one * _moveValue;

            if (transform.localScale.x >= _maxScaleValue) _isInflate = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            //爆発
            Debug.Log("Bomb!!");
            _isInflate = false;
            Firing();
        }
    }

    private void Firing()
    {
        _renderer.enabled = false;
        Instantiate(_fireworkPrefab, transform.position, Quaternion.identity);
    }
}
