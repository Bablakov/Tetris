using System;
using UnityEngine;

public class UIControllerGame : MonoBehaviour, IDisposable {
    private EventBus _eventBus;
    private PanelPause _panelPause;
    private PanelControl _panelControl;
    private PanelFinished _panelFinished;
    private PanelWithNextFigure _panelWithNextFigure;
    private PanelWithScoreAndButton _panelWithScoreAndButton;

    public void Initialize() {
        GetComponents();
        InitializeComponents();
    }

    private void GetComponents() {
        _eventBus = ServiceLocator.Current.Get<EventBus>();
        _panelPause = GetComponentInChildren<PanelPause>();
        _panelControl = GetComponentInChildren<PanelControl>();
        _panelFinished = GetComponentInChildren<PanelFinished>();
        _panelWithNextFigure = GetComponentInChildren<PanelWithNextFigure>();
        _panelWithScoreAndButton = GetComponentInChildren<PanelWithScoreAndButton>();
    }

    private void InitializeComponents() {
        _panelPause.Initialize(_eventBus);
        _panelFinished.Initialize(_eventBus);
        _panelWithNextFigure.Initialize(_eventBus);
        _panelWithScoreAndButton.Initialize(_eventBus);
    }

    public void Dispose() {
        _panelPause.Dispose();
        _panelFinished.Dispose();
        _panelWithNextFigure.Dispose();
        _panelWithScoreAndButton.Dispose();
    }
}