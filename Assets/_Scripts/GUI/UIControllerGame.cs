using System;
using TMPro;
using UnityEngine;

public class UIControllerGame : MonoBehaviour, IDisposable {    
    private ViewQueueFigure _viewQueueFigure;
    private ViewSwapFigure _viewSwapFigure;
    private ViewScoreLine _viewScoreLine;
    private ViewScorePoints _viewScore;
    private ButtonPauseGame _buttonPauseGame;
    private PanelPause _panelPause;
    private EventBus _eventBus;

    public void Initialize() {
        GetComponents();
        InitializeComponents();
    }

    private void GetComponents() {
        _eventBus = ServiceLocator.Current.Get<EventBus>();
        _viewScore = GetComponentInChildren<ViewScorePoints>();
        _viewScoreLine = GetComponentInChildren<ViewScoreLine>();
        _viewSwapFigure = GetComponentInChildren<ViewSwapFigure>();
        _viewQueueFigure = GetComponentInChildren<ViewQueueFigure>();
        _buttonPauseGame = GetComponentInChildren<ButtonPauseGame>();
        _panelPause = GetComponentInChildren<PanelPause>();
    }

    private void InitializeComponents() {
        _viewScore.Initialize(_eventBus);
        _viewScoreLine.Initialize(_eventBus);
        _viewSwapFigure.Initialize(_eventBus);
        _viewQueueFigure.Initialize(_eventBus);
        _buttonPauseGame.Initialize(_eventBus);
        _panelPause.Initialize(_eventBus);
    }

    public void Dispose() {
        _viewQueueFigure.Dispose();
        _viewSwapFigure.Dispose();
        _viewScoreLine.Dispose();
        _viewScore.Dispose();
        _buttonPauseGame.Dispose();
        _panelPause.Dispose();
    }
}