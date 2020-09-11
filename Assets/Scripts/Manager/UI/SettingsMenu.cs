using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public void SetMusicVolume(float volume)
    {
        print((volume * 100).ToString("F0") + "%");
    }
    
    public void SetEffectVolume(float volume)
    {
        print((volume * 100).ToString("F0") + "%");
    }
}
