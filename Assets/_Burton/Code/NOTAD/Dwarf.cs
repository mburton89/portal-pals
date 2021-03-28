using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dwarf : MonoBehaviour
{
    public List<AudioClip> grabAudioClips;
    public AudioSource grabAudioSource;

    public List<AudioClip> throwAudioClips;
    public AudioSource throwAudioSource;

    public void PlayRandomGrabSound()
    {
        grabAudioSource.clip = grabAudioClips[Random.Range(0, grabAudioClips.Count)];
        grabAudioSource.Play();
    }

    public void HandleGrab()
    {
        PlayRandomGrabSound();
    }

    public void PlayRandomThrowSound()
    {
        grabAudioSource.Stop();
        throwAudioSource.clip = throwAudioClips[Random.Range(0, throwAudioClips.Count)];
        throwAudioSource.Play();
    }

    public void HandleThrow()
    {
        PlayRandomThrowSound();
    }
}
