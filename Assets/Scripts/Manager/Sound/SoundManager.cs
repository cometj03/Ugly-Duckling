using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum eMusic
{
    MAIN, SUMMER, AUTUMN, WINTER, SPRING
}

public class SoundManager : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource sfxSource;

    public AudioClip[] BGM;
    private Dictionary<eMusic, AudioClip> bgmDictionary = new Dictionary<eMusic, AudioClip>();

    public static SoundManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        
        for (int i = 0; i < BGM.Length; i++)
        {
            bgmDictionary.Add((eMusic) i, BGM[i]);
        }
    }

    private void Start()
    {
        SetMusicVolume(PlayerData.Instance.musicVolume);
        SetSFXVolume(PlayerData.Instance.sfxVolume);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("change");
            ChangeBGM(eMusic.SUMMER);
        }
    }

    public void SetMusicVolume(float volume)
    {
        musicSource.volume = volume;
        PlayerData.Instance.musicVolume = volume;
    }

    public void SetSFXVolume(float volume)
    {
        sfxSource.volume = volume;
        PlayerData.Instance.sfxVolume = volume;
    }

    public void ChangeBGM(eMusic musicIndex) => StartCoroutine(ChangeMusic(bgmDictionary[musicIndex]));
    
    IEnumerator ChangeMusic(AudioClip otherAudioClip)
    {
        float originVol = PlayerData.Instance.musicVolume;
        float volume = originVol;
        while (volume > 0)
        {
            volume -= 0.01f;
            musicSource.volume = volume;
            yield return null;
        }

        volume = 0;
        yield return new WaitForSeconds(0.2f);
        musicSource.clip = otherAudioClip;
        musicSource.Play();

        while (volume < originVol)
        {
            volume += 0.01f;
            musicSource.volume = volume;
            yield return null;
        }

        musicSource.volume = originVol;
    }
}
