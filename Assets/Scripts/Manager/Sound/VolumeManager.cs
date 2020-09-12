using UnityEngine;
using UnityEngine.Audio;

public class VolumeManager : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void SetMusicVolume(float volume)
    {
        // audioSource.volume = volume;
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(volume) * 20);
        print(Mathf.Log10(volume) * 20);
    }
    
    public void SetEffectVolume(float volume)
    {
        //print((volume * 100).ToString("F0") + "%");
    }
}
