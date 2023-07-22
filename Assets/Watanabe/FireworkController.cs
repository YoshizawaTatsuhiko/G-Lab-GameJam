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

    private Firing _firing = default;
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
        transform.localScale = Vector3.one * 0.2f;
        _moveValue = 1f;
    }

    private void Update()
    {
        if (_firing && !_firing.PlayAnimation())
        {
            SettingDefault();
            _firing = null;
        }

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
            transform.localScale = Vector3.one * _moveValue * 0.2f;

            if (transform.localScale.x >= _maxScaleValue * 0.2f) _isInflate = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            //発射
            Debug.Log("Bomb!!");
            _isInflate = false;
            Firing();
        }
    }

    private void Firing()
    {
        _renderer.enabled = false;
        var go = Instantiate(_fireworkPrefab, transform.position, Quaternion.identity);
        _firing = go.GetComponent<Firing>();
    }
}
