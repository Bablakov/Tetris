using System;
using UnityEngine;

public abstract class InputGame : MonoBehaviour, IService, IDisposable {
    public abstract event Action InputedSwapFigure;
    public abstract event Action InputedHardDrope;
    public abstract event Action InputedRotate;
    public abstract event Action<Vector2> InputedMove;

    protected InputPlayerSystem InputPlayerSystem;
    protected EventBus EventBus;
    protected bool Finished = false;

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
        Finish();
    }

    protected virtual void Subscribe() {
        EventBus.Subscribe<PausedGameSignal>(OnPausedGame);
        EventBus.Subscribe<FinishedGameSignal>(OnFinishedGame);
        EventBus.Subscribe<ResumedGameSignal>(OnStartedGame);
    }

    protected virtual void Unsubscribe() {
        EventBus.Unsubscribe<PausedGameSignal>(OnPausedGame);
        EventBus.Unsubscribe<FinishedGameSignal>(OnFinishedGame);
        EventBus.Unsubscribe<ResumedGameSignal>(OnStartedGame);
    }

    private void GetComponent() {
        if (InputPlayerSystem == null) {
            InputPlayerSystem = new InputPlayerSystem();
        }
        InputPlayerSystem.Player.Enable();
        EventBus = ServiceLocator.Current.Get<EventBus>();
    }

    private void Enable() {
        enabled = true;
    }

    private void Disable() {
        enabled = false;
    }

    private void Finish() {
        Finished = true;
        Disable();
    }

    public void Dispose() {
        Unsubscribe();
    }
}