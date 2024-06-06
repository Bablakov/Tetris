using UnityEngine;

public class SoundChangedPropertyFigure : Sound {
    private AudioClip _soundMove;
    private AudioClip _soundRotate;
    private EventBus _eventBus;

    public void Initialize(EventBus eventBus, SoundConfig config) {
        base.Initialize(config);
        _eventBus = eventBus;
        Subscribe();
    }

    protected override void SetValue(SoundConfig config) {
        _soundMove = config.MoveFigure;
        _soundRotate = config.RotateFigure;
    }


    private void Subscribe() {
        _eventBus.Subscribe<ChangedPropertyFigureSignal>(OnChangedPropertyFigure);
    }

    private void Unsubscribe() {
        _eventBus.Unsubscribe<ChangedPropertyFigureSignal>(OnChangedPropertyFigure);
    }

    private void OnChangedPropertyFigure(ChangedPropertyFigureSignal signal) {
        if (signal.IsRotateChanged) {
            AudioSource.clip = _soundRotate;
        } else {
            AudioSource.clip = _soundMove;
        }
        AudioSource.Play();
    }

    public void Dispose() {
        Unsubscribe();
    }
}