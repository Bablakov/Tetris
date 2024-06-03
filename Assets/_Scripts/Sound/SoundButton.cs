using System;
using UnityEngine;

public class SoundButton : MonoBehaviour, IDisposable {
    private AudioSource _audioSource;
    private AudioClip _soundClickButton;
    private EventBus _eventBus;

    public void Initialize(EventBus eventBus, SoundConfig config) {
        _eventBus = eventBus;
        _soundClickButton = config.ClickButton;
        GetComponent();
        Subscribe();
    }

    public void SetVolume(float value) {
        _audioSource.volume = value;
    }

    private void GetComponent() {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Subscribe() {
        _eventBus.Subscribe<ClickedButtonSignal>(OnClickedButton);
    }

    private void Unsubscribe() {
        _eventBus.Unsubscribe<ClickedButtonSignal>(OnClickedButton);
    }

    private void OnClickedButton(ClickedButtonSignal signal) {
        _audioSource.clip = _soundClickButton;
        _audioSource.Play();
    }

    public void Dispose() {
        Unsubscribe();
    }
}