using System;
using UnityEngine;

public abstract class InputGame : MonoBehaviour, IService {
    public abstract event Action InputedSwapFigure;
    public abstract event Action InputedHardDrope;
    public abstract event Action InputedRotate;
    public abstract event Action InputedRight;
    public abstract event Action InputedDown;
    public abstract event Action InputedLeft;
    protected bool _enabled = true;
    protected EventBus _eventBus;

    public virtual void Initialize() {
        _eventBus = ServiceLocator.Current.Get<EventBus>();
        _eventBus.Subscribe<PausedGameSignal>(OnPausedGame);
        _eventBus.Subscribe<FinishedGameSignal>(OnFinishedGame);
    }

    protected virtual void OnPausedGame(PausedGameSignal signal) {
        if (_enabled) {
            _enabled = false;
            enabled = false;
        } else {
            _enabled = true;
            enabled = true;
        }
    }

    protected virtual void OnFinishedGame(FinishedGameSignal signal) {
        enabled = false;
    }
}