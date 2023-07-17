using UnityEngine;

public class Firework : MonoBehaviour
{
    [SerializeField]
    private Sprite[] _fireworkSprites = default;

    private SpriteRenderer _renderer = default;

    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    public void ShowFirework(int index)
    {
        _renderer.sprite = _fireworkSprites[index];
    }
}
