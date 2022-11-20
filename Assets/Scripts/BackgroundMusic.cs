using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public static BackgroundMusic instance;

    public AudioSource musicOutRounds;
    public AudioSource musicInRounds;

    float defaultVolume = 0.2f;
    float transitionTime = 0.25f;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        musicOutRounds.volume *= GameManager.instance.volumeMultiplierPublic;
        musicInRounds.volume *= GameManager.instance.volumeMultiplierPublic;
    }

    public void ChangeClip()
    {
        AudioSource nowPlaying = musicOutRounds;
        AudioSource target = musicInRounds;

        if (!nowPlaying.isPlaying)
        {
            nowPlaying = musicInRounds;
            target = musicOutRounds;
        }

        StartCoroutine(MixSources(nowPlaying, target));
    }

    IEnumerator MixSources(AudioSource nowPlaying, AudioSource target)
    {
        float percentage = 0;
        while (nowPlaying.volume > 0)
        {
            nowPlaying.volume = Mathf.Lerp(defaultVolume, 0, percentage);
            percentage += Time.deltaTime / transitionTime;
            yield return null;
        }

        nowPlaying.Pause();
        if (!target.isPlaying)
        {
            target.Play();
        }
        target.UnPause();
        percentage = 0;

        while (target.volume < defaultVolume)
        {
            target.volume = Mathf.Lerp(0, defaultVolume, percentage);
            target.volume *= GameManager.instance.volumeMultiplierPublic;
            percentage += Time.deltaTime / transitionTime;
            yield return null;
        }
    }
}
