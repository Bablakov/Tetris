using System;
using UnityEngine;

public class SoundGame : MonoBehaviour, IDisposable{
    private const string WAY_CONFIG = "SoundConfig";

    private SoundBackground _soundBackground;
    private SoundButton _soundButton;
    private SoundField _soundField;
    private SoundFigure _soundFigure;
    private SoundConfig _soundConfig;
    private EventBus _eventBus;


    public void Initialize() {
        GetComponents();
        InitializeComponents();
    }

    private void GetComponents() {
        _eventBus = ServiceLocator.Current.Get<EventBus>();
        _soundConfig = Resources.Load<SoundConfig>(WAY_CONFIG);
        _soundBackground = GetComponentInChildren<SoundBackground>();
        _soundButton = GetComponentInChildren<SoundButton>();
        _soundField = GetComponentInChildren<SoundField>();
        _soundFigure = GetComponentInChildren<SoundFigure>();
    }

    private void InitializeComponents() {
        _soundBackground.Initialize(_soundConfig);
        _soundButton.Initialize(_eventBus, _soundConfig);
        _soundField.Initialize(_eventBus, _soundConfig);
        _soundFigure.Initialize(_eventBus, _soundConfig);
    }

    public void Dispose() {
        _soundButton.Dispose();
        _soundField.Dispose();
        _soundFigure.Dispose();
    }
}