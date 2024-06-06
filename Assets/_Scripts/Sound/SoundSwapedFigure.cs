using UnityEngine;

public class SoundSwapedFigure : Sound {
    private AudioClip _soundSwapFigure;
    private EventBus _eventBus;

    public void Initialize(EventBus eventBus, SoundConfig config) {
        base.Initialize(config);
        _eventBus = eventBus;
        Subscribe();
    }

    protected override void SetValue(SoundConfig config) {
        _soundSwapFigure = config.SwapFigure;
    }


    private void Subscribe() {
        _eventBus.Subscribe<SwapedFigureSignal>(OnSwapedFigure);
    }

    private void Unsubscribe() {
        _eventBus.Unsubscribe<SwapedFigureSignal>(OnSwapedFigure);
    }

    private void OnSwapedFigure(SwapedFigureSignal signal) {
        AudioSource.clip = _soundSwapFigure;
        AudioSource.Play();
    }

    public void Dispose() {
        Unsubscribe();
    }
}