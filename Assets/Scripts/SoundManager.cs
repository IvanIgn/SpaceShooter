using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public GameObject soundEffect;
    public AudioClip[] audioClips;


    public void PlaySound(int soundN)
    {
        GameObject sound = Instantiate(soundEffect, Vector2.zero, Quaternion.identity) as GameObject;
        AudioSource audSource = sound.GetComponent<AudioSource>();

        audSource.clip = audioClips[soundN];
        audSource.Play();
        Destroy(sound, audioClips[soundN].length);
    }
    
}
