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

        //SoundManager.instance.SoundSelection(0, 0.5f);
        //SoundManager.SoundPlay.SoundSelection(shootClip, 0.5f);
    }

    public void SoundSelection(int index, float volume)
    {
        controlAudio.PlayOneShot(audios[index], volume);
    }

    public void SoundPlay(AudioClip clip, float volume)
    {
        controlAudio.PlayOneShot(clip, volume);
    }
}
