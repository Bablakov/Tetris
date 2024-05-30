using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ButtonPauseGame : MonoBehaviour {
    private Button _button;
    private UnityAction _buttonClickPause;
    private EventBus _eventBus;

    public void Initialize(EventBus eventBus) {
        _eventBus = eventBus;
        GetComponents();
        CreateButton();
    }

    private void GetComponents() {
        _button = GetComponent<Button>();
    }

    private void CreateButton() {
        _buttonClickPause += PauseGame;
        _button.onClick.AddListener(_buttonClickPause);
    }

    private void PauseGame() {
        _eventBus.Invoke(new PausedGameSignal());
    }
}