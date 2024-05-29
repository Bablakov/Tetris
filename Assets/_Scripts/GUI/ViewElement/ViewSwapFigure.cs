using System;
using UnityEngine;
using UnityEngine.UI;

public class ViewSwapFigure : MonoBehaviour, IDisposable {
    private EventBus _eventBus;
    private Image _image;

    public void Initialize(EventBus eventBus) {
        _eventBus = eventBus;
        GetComponent();
        Subscribe();
    }

    private void GetComponent() {
        _image = GetComponent<Image>();
    }

    private void Subscribe() {
        _eventBus.Subscribe<SwapedFigureVisualSignal>(OnSwapedFigure);
    }

    private void Unsubscribe() {
        _eventBus.Unsubscribe<SwapedFigureVisualSignal>(OnSwapedFigure);
    }

    private void OnSwapedFigure(SwapedFigureVisualSignal signal) {
        _image.sprite = signal.FigureSwaped.SpriteFigure;
    }

    public void Dispose() {
        Unsubscribe();
    }
}