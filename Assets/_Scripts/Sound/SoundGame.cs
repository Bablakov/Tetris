using System;
using UnityEngine;

public class SoundGame : MonoBehaviour, IDisposable{
    private const string WAY_SOUND_CONFIG = "SoundConfig";
    private const string WAY_SETTINGS_CONFIG = "SettingsConfig";

    private SoundBackground _soundBackground;
    private SoundButton _soundButton;
    private SoundField _soundField;
    private SoundFigure _soundFigure;
    private SoundConfig _soundConfig;
    private SettingsConfig _settingsConfig;
    private EventBus _eventBus;

    public void Initialize() {
        GetComponents();
        InitializeComponents();
        SetVolume();
        Subscribe();
    }

    private void Subscribe() {
        _settingsConfig.ChangedSettings += OnChangedSettings;
    }

    private void Unsubscribe() {
        _settingsConfig.ChangedSettings -= OnChangedSettings;
    }

    private void GetComponents() {
        _eventBus = ServiceLocator.Current.Get<EventBus>();
        _soundConfig = Resources.Load<SoundConfig>(WAY_SOUND_CONFIG);
        _settingsConfig = Resources.Load<SettingsConfig>(WAY_SETTINGS_CONFIG);
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

    private void OnChangedSettings() {
        SetVolume();
    }

    private void SetVolume() {
        _soundBackground.SetVolume(_settingsConfig.MusicVolume);
        _soundButton.SetVolume(_settingsConfig.UIVolume);
        _soundField.SetVolume(_settingsConfig.GameVolume);
        _soundFigure.SetVolume(_settingsConfig.GameVolume);
    }

    public void Dispose() {
        _soundButton.Dispose();
        _soundField.Dispose();
        _soundFigure.Dispose();
        Unsubscribe();
    }
}