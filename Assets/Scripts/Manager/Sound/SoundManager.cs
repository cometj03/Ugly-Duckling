using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource sfxSource;

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
            // return;
        }
    }

    private void Start()
    {
        SetMusicVolume(PlayerData.Instance.musicVolume);
        SetSFXVolume(PlayerData.Instance.sfxVolume);
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
}
