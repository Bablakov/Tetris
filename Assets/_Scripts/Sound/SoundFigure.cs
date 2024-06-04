using System;
using UnityEngine;

public class SoundFigure : Sound, IDisposable {
    private AudioClip _soundMove;
    private AudioClip _soundRotate;
    private AudioClip _soundSoftDrop;
    private AudioClip _soundHardDrop;
    private AudioClip _soundSwapFigure;
    private EventBus _eventBus;

    public void Initialize(EventBus eventBus, SoundConfig config) {
        base.Initialize(config);
        _eventBus = eventBus;
        GetComponent();
        Subscribe();
    }

    protected override void SetValue(SoundConfig config) {
        _soundMove = config.MoveFigure;
        _soundRotate = config.RotateFigure;
        _soundSoftDrop = config.SoftDropFigure;
        _soundHardDrop = config.HardDropFigure;
        _soundSwapFigure = config.SwapFigure;
    }


    private void Subscribe() {
        _eventBus.Subscribe<ChangedPropertyFigureSignal>(OnChangedPropertyFigure);
        _eventBus.Subscribe<SwapedFigureSignal>(OnSwapedFigure);
        _eventBus.Subscribe<PutFigureSignal>(OnPutFigure);
    }

    private void Unsubscribe() {
        _eventBus.Unsubscribe<ChangedPropertyFigureSignal>(OnChangedPropertyFigure);
        _eventBus.Unsubscribe<SwapedFigureSignal>(OnSwapedFigure);
        _eventBus.Unsubscribe<PutFigureSignal>(OnPutFigure);
    }

    private void OnChangedPropertyFigure(ChangedPropertyFigureSignal signal) { 
        if (signal.IsRotateChanged) {
            AudioSource.clip = _soundRotate;
        }
        else {
            AudioSource.clip = _soundMove;
        }
        AudioSource.Play();
    }

    private void OnPutFigure(PutFigureSignal signal) {
        if (signal.IsHardDrop) {
            AudioSource.clip = _soundHardDrop;
        }
        else {
            AudioSource.clip = _soundSoftDrop;
        }
        AudioSource.Play();
    }

    private void OnSwapedFigure(SwapedFigureSignal signal) {
        AudioSource.clip = _soundSwapFigure;
        AudioSource.Play();
    }

    public void Dispose() {
        Unsubscribe();
    }
}