using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public AudioMixer audioMixer;

    public static SoundManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        
        SetMusicVolume(PlayerData.Instance.musicVolume);
        SetSFXVolume(PlayerData.Instance.sfxVolume);
    }

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(volume) * 20);
        PlayerData.Instance.musicVolume = volume;
    }
    
    public void SetSFXVolume(float volume)
    {
        print(Mathf.Log10(volume) * 20);
        PlayerData.Instance.sfxVolume = volume;
    }
}
