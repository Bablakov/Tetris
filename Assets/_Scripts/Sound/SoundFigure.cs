using System;
using UnityEngine;

public class SoundFigure : MonoBehaviour, IDisposable {
    private AudioClip _soundMove;
    private AudioClip _soundRotate;
    private AudioClip _soundSoftDrop;
    private AudioClip _soundHardDrop;
    private AudioClip _soundSwapFigure;
    private AudioSource _audioSource;
    private EventBus _eventBus;

    public void Initialize(EventBus eventBus, SoundConfig config) {
        _eventBus = eventBus;
        _soundMove = config.MoveFigure;
        _soundRotate = config.RotateFigure;
        _soundSoftDrop = config.SoftDropFigure;
        _soundHardDrop = config.HardDropFigure;
        _soundSwapFigure = config.SwapFigure;
        GetComponent();
        Subscribe();
    }

    public void SetVolume(float value) {
        _audioSource.volume = value;
    }

    private void GetComponent() {
        _audioSource = GetComponent<AudioSource>();
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
            _audioSource.clip = _soundRotate;
        }
        else {
            _audioSource.clip = _soundMove;
        }
        _audioSource.Play();
    }

    private void OnPutFigure(PutFigureSignal signal) {
        if (signal.IsHardDrop) {
            _audioSource.clip = _soundHardDrop;
        }
        else {
            _audioSource.clip = _soundSoftDrop;
        }
        _audioSource.Play();
    }

    private void OnSwapedFigure(SwapedFigureSignal signal) {
        _audioSource.clip = _soundSwapFigure;
        _audioSource.Play();
    }

    public void Dispose() {
        Unsubscribe();
    }
}