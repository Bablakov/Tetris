using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ButtonStartGame : MonoBehaviour, IDisposable {
    private UnityAction _buttonClickStart;
    private EventBus _eventBus;
    private Image _image;
    private Button _button;

    public void Initialize(EventBus eventBus) {
        _eventBus = eventBus;
        GetComponents();
        _image.enabled = false;
        _buttonClickStart += StartGame;
        _buttonClickStart += OnStartedGame;
        _button.onClick.AddListener(_buttonClickStart);
        _eventBus.Subscribe<PausedGameSignal>(OnPausedGame);
        
    }

    private void OnStartedGame() {
        _image.enabled = false;
    }

    private void OnPausedGame(PausedGameSignal signal) {
        _image.enabled = true;
    }

    private void GetComponents() {
        _image = GetComponent<Image>();
        _button = GetComponent<Button>();
    }

    private void StartGame() {
        _eventBus.Invoke(new StartedGameSignal());
    }

    public void Dispose() {

    }
}