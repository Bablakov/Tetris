using UnityEngine;

public class SoundPutFigure : Sound{
    private AudioClip _soundSoftDrop;
    private AudioClip _soundHardDrop;
    private EventBus _eventBus;

    public void Initialize(EventBus eventBus, SoundConfig config) {
        base.Initialize(config);
        _eventBus = eventBus;
        Subscribe();
    }

    protected override void SetValue(SoundConfig config) {
        _soundSoftDrop = config.SoftDropFigure;
        _soundHardDrop = config.HardDropFigure;
    }


    private void Subscribe() {
        _eventBus.Subscribe<PutFigureSignal>(OnPutFigure);
    }

    private void Unsubscribe() {
        _eventBus.Unsubscribe<PutFigureSignal>(OnPutFigure);
    }

    private void OnPutFigure(PutFigureSignal signal) {
        if (signal.IsHardDrop) {
            AudioSource.clip = _soundHardDrop;
        } else {
            AudioSource.clip = _soundSoftDrop;
        }
        AudioSource.Play();
    }

    public void Dispose() {
        Unsubscribe();
    }
}