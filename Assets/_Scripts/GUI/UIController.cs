using System;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour {
    private ViewScore _viewScore;
    private EventBus _eventBus;

    public void Initialize() {
        GetComponents();
        InitializeComponents();
    }

    private void InitializeComponents() {
        _viewScore.Initialize(_eventBus);
    }

    private void GetComponents() {
        _eventBus = ServiceLocator.Current.Get<EventBus>();
        _viewScore = GetComponentInChildren<ViewScore>();
    }

    private void Subscribe() {
    }

    private void Unsubscribe() {
    }
}