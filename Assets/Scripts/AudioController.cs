using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] AudioSource _gameAudioSource;
    [SerializeField] AudioSource _collectibleAudioSource;

    [SerializeField] AudioSource _finishAudioSource;

    private void Start()
    {
        _gameAudioSource.Play();
    }

    public void PlayCollectibleSound()
    {
        _collectibleAudioSource.Play();
    }

    public void PlayFinishSound()
    {
        _finishAudioSource.Play();
    }
}