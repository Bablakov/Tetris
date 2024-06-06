using System;
using TMPro;

public class PanelFinished : HidingPanel, IDisposable {
    private TextMeshProUGUI _text;
    private ButtonGoMenu _buttonGoMenu;
    private ButtonExitGame _buttonExitGame;
    private ButtonRestartGame _buttonRestartGame;
    private ViewScoreLineFinished _viewScoreLineFinished;
    private ViewScorePointsFinished _viewScorePointsFinished;
    private ViewBestScoreLineFinished _viewBestScoreLineFinished;
    private ViewBestScorePointsFinished _viewBestScorePointsFinished;

    public override void Initialize(EventBus eventBus) {
        base.Initialize(eventBus);
        Subscribe();
    }

    protected override void GetComponents() {
        base.GetComponents();
        _text = GetComponentInChildren<TextMeshProUGUI>();
        _buttonGoMenu = GetComponentInChildren<ButtonGoMenu>();
        _buttonExitGame = GetComponentInChildren<ButtonExitGame>();
        _buttonRestartGame = GetComponentInChildren<ButtonRestartGame>();
        _viewScoreLineFinished = GetComponentInChildren<ViewScoreLineFinished>();
        _viewScorePointsFinished = GetComponentInChildren<ViewScorePointsFinished>();
        _viewBestScoreLineFinished = GetComponentInChildren<ViewBestScoreLineFinished>();
        _viewBestScorePointsFinished = GetComponentInChildren<ViewBestScorePointsFinished>();
    }

    protected override void InitializeComponents() {
        _buttonGoMenu.Initialize(EventBus);
        _buttonExitGame.Initialize(EventBus);
        _buttonRestartGame.Initialize(EventBus);
        _viewScoreLineFinished.Initialize(EventBus);
        _viewScorePointsFinished.Initialize(EventBus);
        _viewBestScoreLineFinished.Initialize(EventBus);
        _viewBestScorePointsFinished.Initialize(EventBus);
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

    public override void Hide() {
        base.Hide();
        HideChildren();
    }

    private void ShowChildren() {
        _text.enabled = true;
        _buttonGoMenu.Show();
        _buttonExitGame.Show();
        _buttonRestartGame.Show();
        _viewScoreLineFinished.Show();
        _viewScorePointsFinished.Show();
        _viewBestScoreLineFinished.Show();
        _viewBestScorePointsFinished.Show();
    }

    private void HideChildren() {
        _text.enabled = false;
        _buttonGoMenu.Hide();
        _buttonExitGame.Hide();
        _buttonRestartGame.Hide();
        _viewScoreLineFinished.Hide();
        _viewScorePointsFinished.Hide();
        _viewBestScoreLineFinished.Hide();
        _viewBestScorePointsFinished.Hide();
    }

    public void Dispose() {
        Unsubscribe();
    }
}