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
    private AudioPlayer _audio = default;

    public void Init(Transform transform)
    {
        _transform = transform;
        _startPos = transform.position;
        _audio = transform.GetComponent<AudioPlayer>();
    }

    public void Explode(GameObject firework)
    {
        GameObject go = default;
        var sequence = DOTween.Sequence();

        sequence
            .AppendCallback(() =>
            {
                firework.transform.localScale = Vector3.one * 0.1f;
            })
            .Append(_transform.DOMove(_startPos + _upOffset, 1f))
            .Join(firework.transform.DOMove(_startPos + _upOffset, 1f))
            .AppendCallback(() =>
            {
                firework.SetActive(false);
            })
            .AppendCallback(() =>
            {
                _audio.PlaySE(Random.Range(0, _audio.FireworkSE.Length));
                go = Object.Instantiate(_explodePrefab, _transform.position, Quaternion.identity);
            })
            .AppendInterval(2f)
            .AppendCallback(() =>
            {
                firework.SetActive(true);
                firework.transform.localScale = Vector3.one;
                firework.transform.position = _startPos;

                _transform.position = _startPos;
                Object.Destroy(go);
            });
    }
}
