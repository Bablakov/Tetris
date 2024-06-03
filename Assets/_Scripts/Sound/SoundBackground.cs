using System;
using UnityEngine;

public class SoundBackground : MonoBehaviour {
    private AudioSource _audioSource;
    private AudioClip _soundBackground;

    public void Initialize(SoundConfig config) {
        _soundBackground = config.Background;
        GetComponent();
        StartPlay();
    }

    public void SetVolume(float value) {
        _audioSource.volume = value;
    }

    private void GetComponent() {
        _audioSource = GetComponent<AudioSource>();
    }

    private void StartPlay() {
        _audioSource.clip = _soundBackground;
        _audioSource.loop = true;
        _audioSource.Play();
    }
}