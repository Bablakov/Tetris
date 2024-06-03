using System;
using UnityEngine;

public class GameTimeController : IDisposable {
    private EventBus _eventBus;

    public GameTimeController(EventBus eventBus) {
        _eventBus = eventBus;
        Subscribe();
    }

    private void Subscribe() {
        _eventBus.Subscribe<FinishedGameSignal>(OnFinishedGame);
        _eventBus.Subscribe<PausedGameSignal>(OnPausedGame);
        _eventBus.Subscribe<ResumedGameSignal>(OnStartedGame);
    }

    private void Unsubscribe() {
        _eventBus.Unsubscribe<FinishedGameSignal>(OnFinishedGame);
        _eventBus.Unsubscribe<PausedGameSignal>(OnPausedGame);
        _eventBus.Unsubscribe<ResumedGameSignal>(OnStartedGame);
    }

    private void OnFinishedGame(FinishedGameSignal signal) {
        Time.timeScale = 0;
    }

    private void OnPausedGame(PausedGameSignal signal) {
        Time.timeScale = 0;
    }

    private void OnStartedGame(ResumedGameSignal signal) {
        Time.timeScale = 1;
    }

    public void Dispose() {
        Unsubscribe();
    }
}