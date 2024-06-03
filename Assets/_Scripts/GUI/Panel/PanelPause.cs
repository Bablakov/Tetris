using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class PanelPause : MonoBehaviour {
    private EventBus _eventBus;
    private Image _image;
    private ButtonResumeGame _buttonResumeGame;
    private ButtonWithExternalAction _buttonWithExternalAction;
    private PanelSettings _panelSettings;

    public void Initialize(EventBus eventBus, PanelSettings panelSettings) {
        _eventBus = eventBus;
        _panelSettings = panelSettings;
        GetComponents();
        Subscribe();
        _buttonResumeGame.Initialize(eventBus);
        _buttonWithExternalAction.Initialize(eventBus, ShowSettingsPanel, "Settings");
        Disable();
    }

    private void GetComponents() {
        _buttonResumeGame = GetComponentInChildren<ButtonResumeGame>();
        _buttonWithExternalAction = GetComponentInChildren<ButtonWithExternalAction>();
        _image = GetComponent<Image>();
    }

    private void Subscribe() {
        _eventBus.Subscribe<PausedGameSignal>(OnPausedGame);
        _eventBus.Subscribe<ResumedGameSignal>(OnStartedGame);
    }

    private void Unsubscribe() {
        _eventBus.Unsubscribe<PausedGameSignal>(OnPausedGame);
        _eventBus.Unsubscribe<ResumedGameSignal>(OnStartedGame);
    }

    private void OnPausedGame(PausedGameSignal signal) {
        Enable();
    }

    private void OnStartedGame(ResumedGameSignal signal) {
        Disable();
    }

    private void Enable() {
        _image.enabled = true;
        _buttonWithExternalAction.Show();
    }

    private void Disable() {
        _image.enabled = false;
        _buttonWithExternalAction.Hide();
    }

    private void ShowSettingsPanel() {
        _panelSettings.Show();
    }

    public void Dispose() {
        _buttonResumeGame.Dispose();
        Unsubscribe();
    }
}