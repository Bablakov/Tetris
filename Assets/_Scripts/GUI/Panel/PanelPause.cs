using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PanelPause : MonoBehaviour {
    private EventBus _eventBus;
    private Image _image;
    private ButtonStartGame _buttonStartGame;

    public void Initialize(EventBus eventBus) {
        _eventBus = eventBus;
        _buttonStartGame = GetComponentInChildren<ButtonStartGame>();
        _image = GetComponent<Image>();
        _image.enabled = false;
        _buttonStartGame.Initialize(eventBus);
        Subscribe();
        
    }

    private void Subscribe() {
        _eventBus.Subscribe<PausedGameSignal>(OnPausedGame);
        _eventBus.Subscribe<StartedGameSignal>(OnStartedGame);
    }

    private void Unsubscribe() {
        _eventBus.Unsubscribe<PausedGameSignal>(OnPausedGame);
        _eventBus.Unsubscribe<StartedGameSignal>(OnStartedGame);
    }

    private void OnPausedGame(PausedGameSignal signal) {
        _image.enabled = true;
    }

    private void OnStartedGame(StartedGameSignal signal) {
        _image.enabled = false;
    }

    public void Dispose() {
        _buttonStartGame.Dispose();
        Unsubscribe();
    }
}