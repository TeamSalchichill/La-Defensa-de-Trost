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
        if (GameFlow.instance)
        {
            controlAudio.PlayOneShot(audios[index], volume * GameManager.instance.volumeMultiplierEffectsPublic);
        }
        else
        {
            controlAudio.PlayOneShot(audios[index], volume * GameManager.instance.volumeMultiplierEffectsPublic);
        }
    }

    public void SoundPlay(AudioClip clip, float volume)
    {
        if (GameFlow.instance)
        {
            controlAudio.PlayOneShot(clip, volume * GameManager.instance.volumeMultiplierEffectsPublic);
        }
        else
        {
            controlAudio.PlayOneShot(clip, volume * GameManager.instance.volumeMultiplierEffectsPublic);
        }
    }
}
