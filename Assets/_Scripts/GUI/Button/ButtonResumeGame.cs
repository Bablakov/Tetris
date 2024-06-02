using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ButtonResumeGame : BaseButton, IDisposable {
    private Image _image;

    public override void Initialize(EventBus eventBus) {
        base.Initialize(eventBus);
        GetComponents();
        CreateButton();
        Subscribe();
        Disable();
    }

    private void Subscribe() {
        EventBusMe.Subscribe<PausedGameSignal>(OnPausedGame);
    }

    private void Unsubscribe() {
        EventBusMe.Unsubscribe<PausedGameSignal>(OnPausedGame);
    }

    private void CreateButton() {
        AddMethodInEventClick(ResumeGame);
        AddMethodInEventClick(OnResumedGame);
        AddEventOnButton();
    }

    private void OnResumedGame() {
        Disable();
    }

    private void OnPausedGame(PausedGameSignal signal) {
        Enable();
    }

    private void GetComponents() {
        _image = GetComponent<Image>();
    }

    private void ResumeGame() {
        EventBusMe.Invoke(new ResumedGameSignal());
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