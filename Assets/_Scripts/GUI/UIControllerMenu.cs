using System;
using UnityEngine;

public class UIControllerMenu : MonoBehaviour, IDisposable {
    private ButtonStartGame _buttonStartGame;
    private ButtonExitGame _buttonExitGame;
    private ButtonWithExternalAction _buttonOpenSettings;
    private PanelSettings _panelSettings;
    private EventBus _eventBus;

    public void Initialize() {
        GetComponent();
        InitializeComponent();
        _panelSettings.Hide();
    }
    
    private void GetComponent(){
        _eventBus = ServiceLocator.Current.Get<EventBus>();
        _buttonStartGame = GetComponentInChildren<ButtonStartGame>();
        _buttonExitGame = GetComponentInChildren<ButtonExitGame>();
        _buttonOpenSettings = GetComponentInChildren<ButtonWithExternalAction>();
        _panelSettings = GetComponentInChildren<PanelSettings>();
    }

    private void InitializeComponent() {
        _buttonStartGame.Initialize(_eventBus);
        _buttonExitGame.Initialize(_eventBus);
        _buttonOpenSettings.Initialize(_eventBus, OpenPanelSettings, "Settings");
        _panelSettings.Initialize(_eventBus);
    }

    private void OpenPanelSettings() {
        _panelSettings.Show();
    }

    public void Dispose() {

    }
}