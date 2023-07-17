using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] _fireworkSE = default;

    private AudioSource _seSource = default;

    private void Start()
    {
        _seSource = GetComponent<AudioSource>();
        _seSource.loop = false;
        _seSource.playOnAwake = false;
    }

    public void PlaySE(int index)
    {
        _seSource.PlayOneShot(_fireworkSE[index]);
    }
}
