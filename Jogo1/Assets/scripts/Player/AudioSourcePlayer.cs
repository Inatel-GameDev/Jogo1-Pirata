using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourcePlayer : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip attack;
    public AudioClip jump;



    public void playSound(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }

        
}
