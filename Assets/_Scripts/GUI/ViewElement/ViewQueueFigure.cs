using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ViewQueueFigure : MonoBehaviour, IDisposable {
    [SerializeField] private Image imageFigureSprite;
    
    private EventBus _eventBus;
    private List<Image> _queueFigure;

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
        if (_queueFigure == null) {
            _queueFigure = new List<Image>();
            for (int i = 0; i < signal.Figures.Count(); i++) {
                var image = Instantiate(imageFigureSprite, transform);
                _queueFigure.Add(image);
            }
        }
        for (int i = 0; i < signal.Figures.Count(); i++) {
            _queueFigure[i].sprite = signal.Figures.ElementAt(i).SpriteFigure;
        }
    }

    public void Dispose() {
        Unsubscribe();
    }
}