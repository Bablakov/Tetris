using System;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public abstract class InputGame : MonoBehaviour, IService {
    public abstract event Action InputedSwapFigure;
    public abstract event Action InputedHardDrope;
    public abstract event Action InputedRotate;
    public abstract event Action InputedRight;
    public abstract event Action InputedDown;
    public abstract event Action InputedLeft;
    protected EventBus _eventBus;

    public virtual void Initialize() {
        _eventBus = ServiceLocator.Current.Get<EventBus>();
        _eventBus.Subscribe<PausedGameSignal>(OnPausedGame);
        _eventBus.Subscribe<FinishedGameSignal>(OnFinishedGame);
        _eventBus.Subscribe<StartedGameSignal>(OnStartedGame);
    }

    protected virtual void OnPausedGame(PausedGameSignal signal) {
        enabled = false;
    }

    protected virtual void OnStartedGame(StartedGameSignal signal) { 
        enabled = true; 
    }

    protected virtual void OnFinishedGame(FinishedGameSignal signal) {
        enabled = false;
    }
}