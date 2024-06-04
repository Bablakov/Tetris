using System;
using UnityEngine;

public class SoundField : Sound, IDisposable {
    private AudioClip _soundDestroydLine;
    private EventBus _eventBus;

    public void Initialize(EventBus eventBus, SoundConfig config) {
        base.Initialize(config);
        _eventBus = eventBus;
        Subscribe();
    }

    protected override void SetValue(SoundConfig config) {
        _soundDestroydLine = config.DestroyedLine;
    }

    private void Subscribe() {
        _eventBus.Subscribe<ChangedCountDeleteLineSignal>(OnChangedPropertyFigure);
    }

    private void Unsubscribe() {
        _eventBus.Unsubscribe<ChangedCountDeleteLineSignal>(OnChangedPropertyFigure);
    }

    private void OnChangedPropertyFigure(ChangedCountDeleteLineSignal signal) {
        AudioSource.clip = _soundDestroydLine;
        AudioSource.Play();
    }

    public void Dispose() {
        Unsubscribe();
    }
}