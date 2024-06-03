using UnityEngine;

public class PanelSettings : MonoBehaviour {
    [SerializeField] private VolumeSound valueMusic;
    [SerializeField] private VolumeSound valueGame;
    [SerializeField] private VolumeSound valueUI;
    [SerializeField] private ButtonWithExternalAction exitPanel;
    [SerializeField] private ButtonWithExternalAction saveSettings;

    private const string WAY_SETTINGS_CONFIG = "SettingsConfig";
    private const string MUSIC_TEXT = "Music";
    private const string GAME_TEXT = "Game";
    private const string UI_TEXT = "UI";
    private const string EXIT_SETTINGS_TEXT = "Exit";
    private const string SAVE_SETTINGS_TEXT = "Save";

    private EventBus _eventBus;
    private SettingsConfig _settingsConfig;

    public void Initialize(EventBus eventBus) {
        _eventBus = eventBus;
        _settingsConfig = Resources.Load<SettingsConfig>(WAY_SETTINGS_CONFIG);
        valueMusic.Initialize(MUSIC_TEXT, _settingsConfig.MusicVolume);
        valueGame.Initialize(GAME_TEXT, _settingsConfig.GameVolume);
        valueUI.Initialize(UI_TEXT, _settingsConfig.UIVolume);
        exitPanel.Initialize(_eventBus, Hide, EXIT_SETTINGS_TEXT);
        saveSettings.Initialize(_eventBus, Save, SAVE_SETTINGS_TEXT);
    }

    public void Show() {
        gameObject.SetActive(true);
    }

    private void Hide() {
        gameObject.SetActive(false);
    }

    private void Save() {
        _settingsConfig.SetNewValue(valueGame.GetValue(),
            valueUI.GetValue(), valueMusic.GetValue());
    }
}