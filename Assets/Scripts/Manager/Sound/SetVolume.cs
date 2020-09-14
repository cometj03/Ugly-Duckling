using System;
using UnityEngine;

public class SetVolume : MonoBehaviour
{
    public void MusicVolume(float volume) => SoundManager.instance.SetMusicVolume(volume);
    public void SfxVolume(float volume) => SoundManager.instance.SetSFXVolume(volume);
}
