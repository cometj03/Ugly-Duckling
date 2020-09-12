using UnityEngine;
using UnityEngine.Audio;

public class VolumeManager : MonoBehaviour
{
    public AudioMixer _audioMixer;
    
    public void SetMusicVolume(float volume)
    {
        _audioMixer.SetFloat("MusicVolume", volume);
    }
    
    public void SetEffectVolume(float volume)
    {
        //print((volume * 100).ToString("F0") + "%");
    }
}
