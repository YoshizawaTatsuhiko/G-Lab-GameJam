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
    private int _attackValue = 1;
    [SerializeField]
    private Firework _firework = default;

    private float _moveValue = 1f;
    private bool _isInflate = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //計測開始
            Debug.Log("計測開始");
            _moveValue = 1f;
        }
        else if (Input.GetMouseButton(0))
        {
            if (_isInflate) return;

            //計測中
            _moveValue += (Mathf.Abs(Input.GetAxis("Mouse X")) + Mathf.Abs(Input.GetAxis("Mouse Y"))) * _adjustedValue;
            _firework.gameObject.transform.localScale = Vector3.one * _moveValue;

            if (_firework.gameObject.transform.localScale.x >= _maxScaleValue)
            {
                _isInflate = true;
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            //爆発
            Debug.Log("Bomb!!");
            Explosion();
        }
    }

    private void Explosion()
    {
        _firework.ShowFirework((int)_firework.gameObject.transform.localScale.x);
    }
}
