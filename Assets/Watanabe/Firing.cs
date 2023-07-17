using UnityEngine;
using DG.Tweening;

[System.Serializable]
public class Firing
{
    [SerializeField]
    private GameObject _explodePrefab = default;
    [SerializeField]
    private AudioPlayer _audio = default;
    [SerializeField]
    private Vector3 _upOffset = Vector3.up;

    private Transform _transform = default;
    private Vector3 _startPos = Vector3.zero;

    public void Init(Transform transform)
    {
        _transform = transform;
        _startPos = transform.position;
    }

    public void Explode()
    {
        GameObject go = default;
        var sequence = DOTween.Sequence();

        sequence
            .Append(_transform.DOMove(_startPos + _upOffset, 1f))
            .AppendCallback(() =>
            {
                go = Object.Instantiate(_explodePrefab, _transform.position, Quaternion.identity);
                _audio.PlaySE(Random.Range(0, _audio.FireworkSE.Length));
            })
            .AppendInterval(2f)
            .AppendCallback(() =>
            {
                Object.Destroy(go);
            });
    }
}
