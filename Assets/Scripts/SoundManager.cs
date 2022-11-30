using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioClip[] audios;

    AudioSource controlAudio;

    public void Awake()
    {
        instance = this;

        controlAudio = GetComponent<AudioSource>();
    }

    public void SoundSelection(int index, float volume)
    {
        volume -= 0.25f; 
        controlAudio.PlayOneShot(audios[index], (volume * GameManager.instance.volumeMultiplierEffectsPublic) + ((60 - GameFlow.instance.round) * 0.01f));
    }

    public void SoundPlay(AudioClip clip, float volume)
    {
        volume -= 0.25f;
        controlAudio.PlayOneShot(clip, (volume * GameManager.instance.volumeMultiplierEffectsPublic) + ((60 - GameFlow.instance.round) * 0.01f));
    }
}
