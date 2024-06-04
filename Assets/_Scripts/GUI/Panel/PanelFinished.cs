using System;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UI;

public class PanelFinished : HidingPanel, IDisposable {
    private ButtonGoMenu _buttonGoMenu;
    private ButtonExitGame _buttonExitGame;
    private ButtonRestartGame _buttonRestartGame;
    private ViewScoreLineFinished _viewScoreLineFinished;
    private ViewScorePointsFinished _viewScorePointsFinished;
    private Image _image;

    public override void Initialize(EventBus eventBus) {
        base.Initialize(eventBus);
        Subscribe();
    }

    protected override void GetComponents() {
        base.GetComponents();
        _buttonGoMenu = GetComponentInChildren<ButtonGoMenu>();
        _buttonExitGame = GetComponentInChildren<ButtonExitGame>();
        _buttonRestartGame = GetComponentInChildren<ButtonRestartGame>();
        _viewScoreLineFinished = GetComponentInChildren<ViewScoreLineFinished>();
        _viewScorePointsFinished = GetComponentInChildren<ViewScorePointsFinished>();
    }

    protected override void InitializeComponents() {
        _buttonGoMenu.Initialize(EventBus);
        _buttonExitGame.Initialize(EventBus);
        _buttonRestartGame.Initialize(EventBus);
        _viewScoreLineFinished.Initialize(EventBus);
        _viewScorePointsFinished.Initialize(EventBus);
    }

    private void Subscribe() {
        EventBus.Subscribe<FinishedGameSignal>(ShowAllElements);
    }    

    private void Unsubscribe() {
        EventBus.Unsubscribe<FinishedGameSignal>(ShowAllElements);
    }

    private void ShowAllElements(FinishedGameSignal signal) {
        Show();
    }

    public override void Show() {
        base.Show();
        ShowChildren();
    }

    private void ShowChildren() {
        _buttonGoMenu.Show();
        _buttonExitGame.Show();
        _buttonRestartGame.Show();
        _viewScoreLineFinished.Show();
        _viewScorePointsFinished.Show();
    }

    public override void Hide() {
        base.Hide();
        HideChildren();
    }

    private void HideChildren() {
        _buttonGoMenu.Hide();
        _buttonExitGame.Hide();
        _buttonRestartGame.Hide();
        _viewScoreLineFinished.Hide();
        _viewScorePointsFinished.Hide();
    }

    public void Dispose() {
        Unsubscribe();
    }
}