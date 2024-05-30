using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ViewQueueFigure : MonoBehaviour, IDisposable {
    [SerializeField] private Image imageFigureSprite;

    private bool IsExistCollectionImagesFigure => _imagesFigure != null;

    private EventBus _eventBus;
    private List<Image> _imagesFigure;

    public void Initialize(EventBus eventBus) {
        _eventBus = eventBus;
        Subscribe();
    }

    private void Subscribe() {
        _eventBus.Subscribe<ChangedQueueFigureSignal>(OnChangedQueueFigure);
    }

    private void Unsubscribe() {
        _eventBus.Unsubscribe<ChangedQueueFigureSignal>(OnChangedQueueFigure);
    }

    private void OnChangedQueueFigure(ChangedQueueFigureSignal signal) {
        if (!IsExistCollectionImagesFigure) {
            CreateCollectionImagesFigure(signal.Figures.Count());
        }
        RenderImagesFigure(signal.Figures);
    }

    private void CreateCollectionImagesFigure(int countImage) {
        _imagesFigure = new List<Image>();

        for (int i = 0; i < countImage; i++) {
            var image = Instantiate(imageFigureSprite, transform);
            _imagesFigure.Add(image);
        }
    }

    private void RenderImagesFigure(IEnumerable<Figure> figures) {
        for (int i = 0; i < figures.Count(); i++) {
            _imagesFigure[i].sprite = figures.ElementAt(i).SpriteFigure;
        }
    }

    public void Dispose() {
        Unsubscribe();
    }
}