using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eMusic
{
    MAIN, SUMMER, AUTUMN, WINTER, SPRING
}

public enum eSFX
{
    BtnClick1, BtnClick2, Crunchy, Clear, Over, Jump
}

public class SoundManager : MonoBehaviour
{
    public AudioSource BGM_Source;
    public AudioSource SFX_BtnSource;

    public AudioClip[] BGM;
    public AudioClip[] SFX;
    private Dictionary<eMusic, AudioClip> dictBGM = new Dictionary<eMusic, AudioClip>();
    private Dictionary<eSFX, AudioClip> dictSFX = new Dictionary<eSFX, AudioClip>();

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
        
        // Add to Dictionary
        for (int i = 0; i < BGM.Length; i++)
            dictBGM.Add((eMusic) i, BGM[i]);
        
        for (int i = 0; i < SFX.Length; i++)
            dictSFX.Add((eSFX) i, SFX[i]);
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
        BGM_Source.volume = volume;
        PlayerData.Instance.musicVolume = volume;
    }

    public void SetSFXVolume(float volume)
    {
        SFX_BtnSource.volume = volume;
        PlayerData.Instance.sfxVolume = volume;
    }

    public void ChangeBGM(eMusic musicIndex) => StartCoroutine(ChangeMusic(dictBGM[musicIndex]));
    public void StopBGM() => StartCoroutine(SmoothStopMusic());

    public void PlaySFX(eSFX sfxIndex)
    {
        SFX_BtnSource.clip = dictSFX[sfxIndex];
        SFX_BtnSource.Play();
    }
    
    
    // 배경음악 변경
    IEnumerator ChangeMusic(AudioClip otherAudioClip)
    {
        float originVol = PlayerData.Instance.musicVolume;
        float volume = originVol;
        while (volume > 0)
        {
            volume -= 0.01f;
            BGM_Source.volume = volume;
            yield return null;
        }

        volume = 0;
        yield return new WaitForSeconds(0.5f);
        BGM_Source.clip = otherAudioClip;
        BGM_Source.Play();

        while (volume < originVol)
        {
            volume += 0.01f;
            BGM_Source.volume = volume;
            yield return null;
        }

        BGM_Source.volume = originVol;
    }
    
    // 배경음악 중지
    IEnumerator SmoothStopMusic()
    {
        float originVol = PlayerData.Instance.musicVolume;
        float volume = originVol;
        while (volume > 0)
        {
            volume -= 0.003f;
            BGM_Source.volume = volume;
            yield return null;
        }
        BGM_Source.Stop();
        BGM_Source.volume = originVol;
    }
}
