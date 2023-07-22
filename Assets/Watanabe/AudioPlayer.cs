using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] _fireworkSE = new AudioClip[4];

    private AudioSource _seSource = default;

    public AudioClip[] FireworkSE => _fireworkSE;

    private void Awake()
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
