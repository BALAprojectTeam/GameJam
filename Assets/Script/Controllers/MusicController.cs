using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioClip firstAudioClip;
    public AudioClip secondAudioClip;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = firstAudioClip;
        audioSource.loop = false;
        audioSource.Play();
        audioSource.AddOnCompletedCallback(OnFirstAudioClipCompleted);
    }

    void OnFirstAudioClipCompleted()
    {
        audioSource.clip = secondAudioClip;
        audioSource.loop = true;
        audioSource.Play();
    }

    public void StopAudio()
    {
        audioSource.Stop();
    }
}
