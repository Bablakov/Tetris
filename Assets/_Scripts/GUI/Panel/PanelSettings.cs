using UnityEngine;

public class PanelSettings : HidingPanel {
    [SerializeField] private SetingValue valueMusic;
    [SerializeField] private SetingValue valueGame;
    [SerializeField] private SetingValue valueUI;
    [SerializeField] private ButtonWithExternalAction exitPanel;
    [SerializeField] private ButtonWithExternalAction saveSettings;

    private const string WAY_SETTINGS_CONFIG = "SettingsConfig";
    private const string MUSIC_TEXT = "Music";
    private const string GAME_TEXT = "Game";
    private const string UI_TEXT = "UI";
    private const string EXIT_SETTINGS_TEXT = "Exit";
    private const string SAVE_SETTINGS_TEXT = "Save";

    private SettingsConfig _settingsConfig;

    protected override void GetComponents() {
        _settingsConfig = Resources.Load<SettingsConfig>(WAY_SETTINGS_CONFIG);
    }

    protected override void InitializeComponents() {
        valueMusic.Initialize(MUSIC_TEXT, _settingsConfig.MusicVolume);
        valueGame.Initialize(GAME_TEXT, _settingsConfig.GameVolume);
        valueUI.Initialize(UI_TEXT, _settingsConfig.UIVolume);
        exitPanel.Initialize(EventBus, Hide, EXIT_SETTINGS_TEXT);
        saveSettings.Initialize(EventBus, Save, SAVE_SETTINGS_TEXT);
    }

    public override void Show() {
        gameObject.SetActive(true);
    }

    public override void Hide() {
        gameObject.SetActive(false);
    }

    private void Save() {
        _settingsConfig.SetNewValue(valueGame.GetValue(),
            valueUI.GetValue(), valueMusic.GetValue());
    }
}