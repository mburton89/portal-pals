using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dwarf : MonoBehaviour
{
    public List<AudioClip> grabAudioClips;
    public AudioSource grabAudioSource;

    public List<AudioClip> throwAudioClips;
    public AudioSource throwAudioSource;

    private bool _canMakeThudSound;
    public AudioSource thudSound;


    public void PlayRandomGrabSound()
    {
        grabAudioSource.clip = grabAudioClips[Random.Range(0, grabAudioClips.Count)];
        grabAudioSource.Play();
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (_canMakeThudSound)
    //    {
    //        print("hi");
    //        thudSound.Play();
    //        _canMakeThudSound = false;
    //    }
    //}

    public void HandleGrab()
    {
        PlayRandomGrabSound();
    }

    public void PlayRandomThrowSound()
    {
        _canMakeThudSound = true;
        grabAudioSource.Stop();
        throwAudioSource.clip = throwAudioClips[Random.Range(0, throwAudioClips.Count)];
        throwAudioSource.Play();
    }

    public void HandleThrow()
    {
        PlayRandomThrowSound();
    }
}
