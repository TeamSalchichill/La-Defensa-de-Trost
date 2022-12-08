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
            volume -= 0.25f;
            controlAudio.PlayOneShot(audios[index], (volume * GameManager.instance.volumeMultiplierEffectsPublic) + ((40 - GameFlow.instance.round) * 0.01f));
        }
        else
        {
            controlAudio.PlayOneShot(audios[index], (volume * GameManager.instance.volumeMultiplierEffectsPublic));
        }
    }

    public void SoundPlay(AudioClip clip, float volume)
    {
        if (GameFlow.instance)
        {
            volume -= 0.35f;
            controlAudio.PlayOneShot(clip, (volume * GameManager.instance.volumeMultiplierEffectsPublic) + ((40 - GameFlow.instance.round) * 0.01f));
        }
        else
        {
            controlAudio.PlayOneShot(clip, (volume * GameManager.instance.volumeMultiplierEffectsPublic));
        }
    }
}
