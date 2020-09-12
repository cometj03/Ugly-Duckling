using System;
using UnityEngine;

public class SetVolume : MonoBehaviour
{
    private SoundManager _soundManager;
    private void Awake()
    {
        _soundManager = FindObjectOfType<SoundManager>();
    }

    public void MusicVolume(float volume) => _soundManager.SetMusicVolume(volume);
    public void SfxVolume(float volume) => _soundManager.SetSFXVolume(volume);
}
