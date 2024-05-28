using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ViewQueueFigure : MonoBehaviour {
    [SerializeField] private Image imageFigureSprite;
    
    private EventBus _eventBus;
    private List<Image> _queueFigure;

    public void Initialize(EventBus eventBus) {
        _eventBus = eventBus;
        Subscribe();
    }

    private void Subscribe() {
        _eventBus.Subscribe<ChangeQueueFigureSignal>(OnChangedQueueFigure);
    }

    private void Unsubscribe() {
        _eventBus.Unsubscribe<ChangeQueueFigureSignal>(OnChangedQueueFigure);
    }

    private void OnChangedQueueFigure(ChangeQueueFigureSignal signal) {
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
}