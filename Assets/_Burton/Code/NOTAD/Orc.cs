using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orc : MonoBehaviour
{
    public List<AudioClip> audioClips;
    public AudioSource audioSource;

    private void OnTriggerEnter(Collider other)
    {
    
    }

    public void PlayRandomSound()
    {
        audioSource.clip = audioClips[Random.Range(0, audioClips.Count)];
        audioSource.Play();
    }

    public void ShowFallAnimation()
    {

    }
}
