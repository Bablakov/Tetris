using System;
using Unity.VisualScripting;
using UnityEngine;

public class UIControllerGame : UIController, IDisposable {
    [SerializeField] private Transform panelControl;
    [SerializeField] private Transform panelDescription;

    private PanelPause _panelPause;
    private PanelFinished _panelFinished;
    private PanelWithNextFigure _panelWithNextFigure;
    private PanelWithScoreAndButton _panelWithScoreAndButton;

    public override void Initialize() {
        base.Initialize();
        PanelSettings.Hide();
        if (Application.isMobilePlatform) {
            panelControl.gameObject.SetActive(true);
            panelDescription.gameObject.SetActive(false);
        }
        else {
            panelControl.gameObject.SetActive(false);
            panelDescription.gameObject.SetActive(true);
        }
    }

    protected override void GetComponents() {
        base.GetComponents();
        _panelPause = GetComponentInChildren<PanelPause>();
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