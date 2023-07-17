using DG.Tweening;
using UnityEngine;

public class Firework : MonoBehaviour
{
    [SerializeField]
    private Sprite[] _fireworkSprites = default;
    [SerializeField]
    private LifeManager _lifeManager = default;

    private SpriteRenderer _renderer = default;

    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    public void ShowFirework(int scale)
    {
        _renderer.sprite = _fireworkSprites[scale - 1];

        _renderer.transform.localScale = Vector3.zero;
        _renderer.transform.DOScale(Vector3.one * scale, 1.5f);
    }
}
