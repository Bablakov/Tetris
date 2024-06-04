using System;
using UnityEngine;

public class SoundButton : Sound, IDisposable {
    private AudioClip _soundClickButton;
    private EventBus _eventBus;

    public void Initialize(EventBus eventBus, SoundConfig config) {
        base.Initialize(config);
        _eventBus = eventBus;
        Subscribe();
    }

    protected override void SetValue(SoundConfig config) {
        _soundClickButton = config.ClickButton;
    }

    private void Subscribe() {
        _eventBus.Subscribe<ClickedButtonSignal>(OnClickedButton);
    }

    private void Unsubscribe() {
        _eventBus.Unsubscribe<ClickedButtonSignal>(OnClickedButton);
    }

    private void OnClickedButton(ClickedButtonSignal signal) {
        AudioSource.clip = _soundClickButton;
        AudioSource.Play();
    }

    public void Dispose() {
        Unsubscribe();
    }
}