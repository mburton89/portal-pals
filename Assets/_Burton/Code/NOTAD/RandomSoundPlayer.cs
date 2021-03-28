using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSoundPlayer : MonoBehaviour
{
    public List<AudioClip> audioClips;
    public AudioSource audioSource;

    public void PlayRandomGrabSound()
    {
        audioSource.clip = audioClips[Random.Range(0, audioClips.Count)];
        audioSource.Play();
    }

    void Start()
    {
        PlayRandomGrabSound();
    }
}
