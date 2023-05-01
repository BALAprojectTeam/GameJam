using UnityEngine;
using UnityEngine.Audio;
using System.Collections;


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
        audioSource.clip = firstAudioClip;
        audioSource.loop = false;
        audioSource.Play();
        audioSource.PlayOneShot(firstAudioClip);
        StartCoroutine(PlaySecondAudioClip());
    }

    IEnumerator PlaySecondAudioClip()
    {
        yield return new WaitForSeconds(firstAudioClip.length);
        audioSource.clip = secondAudioClip;
        audioSource.loop = true;
        audioSource.Play();
    }

    public void StopAudio()
    {
        audioSource.Stop();
    }
}
