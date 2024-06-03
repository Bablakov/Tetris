using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;
using UnityEngine;
using System;

public class PanelWithNextFigure : MonoBehaviour {
    private EventBus _eventBus;
    private Image[] _imagesFigure;
    private GridLayoutGroup GridLayoutGroup;

    public void Initialize(EventBus eventBus) {
        _eventBus = eventBus;
        _imagesFigure = GetComponentsInChildren<Image>().Reverse().ToArray();
        Subscribe();
    }

    private void Subscribe() {
        _eventBus.Subscribe<ChangedQueueFigureSignal>(OnChangedQueueFigure);
    }

    private void Unsubscribe() {
        _eventBus.Unsubscribe<ChangedQueueFigureSignal>(OnChangedQueueFigure);
    }

    private void OnChangedQueueFigure(ChangedQueueFigureSignal signal) {

        RenderImagesFigure(signal.Figures);
    }

    private void RenderImagesFigure(IEnumerable<Figure> figures) {
        var length = Math.Min(figures.Count(), _imagesFigure.Length);
        for (int i = 0; i < length; i++) {
            _imagesFigure[i].sprite = figures.ElementAt(i).SpriteFigure;
        }
    }

    public void Dispose() {
        Unsubscribe();
    }
}