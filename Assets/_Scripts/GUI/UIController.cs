using System;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour {
    [SerializeField] private ViewQueueFigure _viewQueueFigure;
    
    private ViewScore _viewScore;
    private EventBus _eventBus;

    public void Initialize() {
        GetComponents();
        InitializeComponents();
    }

    private void GetComponents() {
        _eventBus = ServiceLocator.Current.Get<EventBus>();
        _viewScore = GetComponentInChildren<ViewScore>();
        //_viewQueueFigure = GetComponentInChildren<ViewQueueFigure>();
    }

    private void InitializeComponents() {
        _viewScore.Initialize(_eventBus);
        _viewQueueFigure.Initialize(_eventBus);
    }
}