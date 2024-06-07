using UnityEngine;

public class PanelSettings : HidingPanel {
    [SerializeField] private SetingValue valueMusic;
    [SerializeField] private SetingValue valueGame;
    [SerializeField] private SetingValue valueUI;
    [SerializeField] private ButtonWithExternalAction exitPanel;
    [SerializeField] private ButtonWithExternalAction saveSettings;

    private const string WAY_SETTINGS_CONFIG = "SettingsConfig";

    private SettingsConfig _settingsConfig;

    protected override void GetComponents() {
        _settingsConfig = Resources.Load<SettingsConfig>(WAY_SETTINGS_CONFIG);
    }

    protected override void InitializeComponents() {
        valueMusic.Initialize(_settingsConfig.MusicVolume);
        valueGame.Initialize(_settingsConfig.GameVolume);
        valueUI.Initialize(_settingsConfig.UIVolume);
        exitPanel.Initialize(EventBus, Hide);
        saveSettings.Initialize(EventBus, Save);
    }

    public override void Show() {
        gameObject.SetActive(true);
        valueMusic.SetValue(_settingsConfig.MusicVolume);
        valueGame.SetValue(_settingsConfig.GameVolume);
        valueUI.SetValue(_settingsConfig.UIVolume);
    }

    public override void Hide() {
        gameObject.SetActive(false);
    }

    private void Save() {
        _settingsConfig.SetNewValue(valueGame.GetValue(),
            valueUI.GetValue(), valueMusic.GetValue());
    }
}