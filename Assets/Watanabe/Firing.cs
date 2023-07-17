using UnityEngine;
using DG.Tweening;

[System.Serializable]
public class Firing
{
    [SerializeField]
    private GameObject _explodePrefab = default;
    [SerializeField]
    private Vector3 _upOffset = Vector3.up;

    private Transform _transform = default;
    private Vector3 _startPos = Vector3.zero;

    public GameObject ExplodePrefab => _explodePrefab;

    public void Init(Transform transform)
    {
        _transform = transform;
        _startPos = transform.position;
    }

    public void Explode()
    {
        var sequence = DOTween.Sequence();

        sequence.Append(_transform.DOMove(_startPos + _upOffset, 1f));
    }
}
