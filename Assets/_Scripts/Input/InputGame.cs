using System;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public abstract class InputGame : MonoBehaviour, IService, IDisposable {
    public abstract event Action InputedSwapFigure;
    public abstract event Action InputedHardDrope;
    public abstract event Action InputedRotate;
    public abstract event Action InputedRight;
    public abstract event Action InputedDown;
    public abstract event Action InputedLeft;
    protected EventBus _eventBus;

    public virtual void Initialize() {
        GetComponent();
        Subscribe();
    }

    protected virtual void OnPausedGame(PausedGameSignal signal) {
        Disable();
    }

    protected virtual void OnStartedGame(ResumedGameSignal signal) {
        Enable();
    }

    protected virtual void OnFinishedGame(FinishedGameSignal signal) {
        Disable();
    }

    private void GetComponent() {
        _eventBus = ServiceLocator.Current.Get<EventBus>();
    }

    private void Subscribe() {
        _eventBus.Subscribe<PausedGameSignal>(OnPausedGame);
        _eventBus.Subscribe<FinishedGameSignal>(OnFinishedGame);
        _eventBus.Subscribe<ResumedGameSignal>(OnStartedGame);
    }

    private void Unsubscribe() {
        _eventBus.Unsubscribe<PausedGameSignal>(OnPausedGame);
        _eventBus.Unsubscribe<FinishedGameSignal>(OnFinishedGame);
        _eventBus.Unsubscribe<ResumedGameSignal>(OnStartedGame);
    }

    private void Enable() {
        enabled = true;
    }

    private void Disable() {
        enabled &= false;
    }

    public void Dispose() {
        Unsubscribe();
    }
}