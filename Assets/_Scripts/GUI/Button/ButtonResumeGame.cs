using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ButtonResumeGame : MonoBehaviour, IDisposable {
    private UnityAction _buttonClickResume;
    private EventBus _eventBus;
    private Image _image;
    private Button _button;

    public void Initialize(EventBus eventBus) {
        _eventBus = eventBus;
        GetComponents();
        CreateButton();
        Subscribe();
        Disable();
    }

    private void Subscribe() {
        _eventBus.Subscribe<PausedGameSignal>(OnPausedGame);
    }

    private void Unsubscribe() {
        _eventBus.Unsubscribe<PausedGameSignal>(OnPausedGame);
    }

    private void CreateButton() {
        _buttonClickResume += ResumeGame;
        _buttonClickResume += OnResumedGame;
        _button.onClick.AddListener(_buttonClickResume);
    }

    private void OnResumedGame() {
        Disable();
    }

    private void OnPausedGame(PausedGameSignal signal) {
        Enable();
    }

    private void GetComponents() {
        _image = GetComponent<Image>();
        _button = GetComponent<Button>();
    }

    private void ResumeGame() {
        _eventBus.Invoke(new ResumedGameSignal());
    }

    private void Enable() {
        _image.enabled = true;
    }

    private void Disable() {
        _image.enabled = false;
    }

    public void Dispose() {
        Unsubscribe();
    }
}