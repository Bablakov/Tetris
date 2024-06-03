using System;
using UnityEngine;

public class SoundField : MonoBehaviour, IDisposable {
    private AudioClip _soundDestroydLine;
    private AudioSource _audioSource;
    private EventBus _eventBus;

    public void Initialize(EventBus eventBus, SoundConfig config) {
        _eventBus = eventBus;
        _soundDestroydLine = config.DestroyedLine;
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
        _eventBus.Subscribe<ChangedCountDeleteLineSignal>(OnChangedPropertyFigure);
    }

    private void Unsubscribe() {
        _eventBus.Unsubscribe<ChangedCountDeleteLineSignal>(OnChangedPropertyFigure);
    }

    private void OnChangedPropertyFigure(ChangedCountDeleteLineSignal signal) {
        _audioSource.clip = _soundDestroydLine;
        _audioSource.Play();
    }

    public void Dispose() {
        Unsubscribe();
    }
}