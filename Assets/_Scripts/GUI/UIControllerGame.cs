using System;
using UnityEngine;

public class UIControllerGame : MonoBehaviour, IDisposable {
    private EventBus _eventBus;
    private PanelPause _panelPause;
    private PanelControl _panelControl;
    private PanelFinished _panelFinished;
    private PanelSettings _panelSettings;
    private PanelWithNextFigure _panelWithNextFigure;
    private PanelWithScoreAndButton _panelWithScoreAndButton;

    public void Initialize() {
        GetComponents();
        InitializeComponents();
        _panelSettings.Hide();
    }

    private void GetComponents() {
        _eventBus = ServiceLocator.Current.Get<EventBus>();
        _panelPause = GetComponentInChildren<PanelPause>();
        _panelControl = GetComponentInChildren<PanelControl>();
        _panelFinished = GetComponentInChildren<PanelFinished>();
        _panelSettings = GetComponentInChildren<PanelSettings>();
        _panelWithNextFigure = GetComponentInChildren<PanelWithNextFigure>();
        _panelWithScoreAndButton = GetComponentInChildren<PanelWithScoreAndButton>();
    }

    private void InitializeComponents() {
        _panelFinished.Initialize(_eventBus);
        _panelWithNextFigure.Initialize(_eventBus);
        _panelWithScoreAndButton.Initialize(_eventBus);
        _panelSettings.Initialize(_eventBus);
        _panelPause.Initialize(_eventBus, _panelSettings);
    }

    public void Dispose() {
        _panelPause.Dispose();
        _panelFinished.Dispose();
        _panelWithNextFigure.Dispose();
        _panelWithScoreAndButton.Dispose();
    }
}