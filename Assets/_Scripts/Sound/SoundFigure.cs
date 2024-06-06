using System;
using UnityEngine;

public class SoundFigure : MonoBehaviour, IDisposable {
    private SoundChangedPropertyFigure _soundChangedPropertyFigure;
    private SoundPutFigure _soundPutFigure;
    private SoundSwapedFigure _soundSwapedFigure;

    public void Initialize(EventBus eventBus, SoundConfig config) {
        GetComponents();
        InitializeComponents(eventBus, config);
    }

    private void InitializeComponents(EventBus eventBus, SoundConfig config) {
        _soundChangedPropertyFigure.Initialize(eventBus, config);
        _soundPutFigure.Initialize(eventBus, config);
        _soundSwapedFigure.Initialize(eventBus, config);
    }

    public void SetVolume(float value) {
        _soundChangedPropertyFigure.SetVolume(value);
        _soundPutFigure.SetVolume(value);
        _soundSwapedFigure.SetVolume(value);
    }

    private void GetComponents() {
        _soundChangedPropertyFigure = GetComponentInChildren<SoundChangedPropertyFigure>();
        _soundPutFigure = GetComponentInChildren<SoundPutFigure>();
        _soundSwapedFigure = GetComponentInChildren<SoundSwapedFigure>();
    }


    public void Dispose() {
        _soundChangedPropertyFigure.Dispose();
        _soundPutFigure.Dispose();
        _soundSwapedFigure.Dispose();
    }
}