using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;
using UnityEngine;
using System;

public class PanelWithNextFigure : BasePanel {
    private Image[] _imagesFigure;

    public override void Initialize(EventBus eventBus) {
        base.Initialize(eventBus);
        Subscribe();
    }

    protected override void GetComponents() {
        _imagesFigure = GetComponentsInChildren<Image>();//.Reverse().ToArray();
    }

    private void Subscribe() {
        EventBus.Subscribe<ChangedQueueFigureSignal>(OnChangedQueueFigure);
    }

    private void Unsubscribe() {
        EventBus.Unsubscribe<ChangedQueueFigureSignal>(OnChangedQueueFigure);
    }

    private void OnChangedQueueFigure(ChangedQueueFigureSignal signal) {
        RenderImagesFigure(signal.Figures);
    }

    private void RenderImagesFigure(IEnumerable<Figure> figures) {
        var length = Math.Min(figures.Count(), _imagesFigure.Length);
        for (int i = 0; i < length; i++) {
            var spriteFigure = figures.ElementAt(i).SpriteFigure;
            SetImageFigure(spriteFigure, i);
        }
    }

    private void SetImageFigure(Sprite sprite, int indexImage) {
        _imagesFigure[indexImage].sprite = sprite;
    }

    public void Dispose() {
        Unsubscribe();
    }
}