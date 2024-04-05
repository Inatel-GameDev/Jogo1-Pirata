using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourcePlayer : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip attack;
    public AudioClip jump;
    public AudioClip footstep;
    public AudioClip gold;
    public AudioClip victory;
    public AudioClip lose;
    



    public void playSound(AudioClip clip)
    {
        stopSound();
        audioSource.clip = clip;
        audioSource.Play();
    }

    public void running()
    {
        audioSource.loop = true;
        audioSource.clip = footstep;
        audioSource.Play();
    }

    public void stopSound()
    {
        audioSource.loop = false;
        audioSource.Stop();
    }
        
}
