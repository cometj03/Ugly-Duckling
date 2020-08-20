using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public Text masterVolumeText;
    public Text musicVolumeText;
    public Text effectVolumeText;

    public void SetMasterVolume(float volume)
    {
        masterVolumeText.text = (volume * 100).ToString("F0") + "%";
    }

    public void SetMusicVolume(float volume)
    {
        musicVolumeText.text = (volume * 100).ToString("F0") + "%";
    }
    
    public void SetEffectVolume(float volume)
    {
        effectVolumeText.text = (volume * 100).ToString("F0") + "%";
    }
}
