using System;
using UnityEngine;

public class UIControllerGame : UIController, IDisposable {
    private PanelPause _panelPause;
    private PanelControl _panelControl;
    private PanelFinished _panelFinished;
    private PanelWithNextFigure _panelWithNextFigure;
    private PanelWithScoreAndButton _panelWithScoreAndButton;

    public override void Initialize() {
        base.Initialize();
        PanelSettings.Hide();
    }

    protected override void GetComponents() {
        base.GetComponents();
        _panelPause = GetComponentInChildren<PanelPause>();
        _panelControl = GetComponentInChildren<PanelControl>();
        _panelFinished = GetComponentInChildren<PanelFinished>();
        _panelWithNextFigure = GetComponentInChildren<PanelWithNextFigure>();
        _panelWithScoreAndButton = GetComponentInChildren<PanelWithScoreAndButton>();
    }

    protected override void InitializeComponents() {
        base.InitializeComponents();
        _panelFinished.Initialize(EventBus);
        _panelWithNextFigure.Initialize(EventBus);
        _panelWithScoreAndButton.Initialize(EventBus);
        _panelPause.Initialize(EventBus);
        _panelPause.SetValue(PanelSettings);
    }

    public void Dispose() {
        _panelPause.Dispose();
        _panelFinished.Dispose();
        _panelWithNextFigure.Dispose();
        _panelWithScoreAndButton.Dispose();
    }
}