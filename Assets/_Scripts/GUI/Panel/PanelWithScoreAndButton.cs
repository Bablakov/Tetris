using System;

public class PanelWithScoreAndButton : BasePanel, IDisposable {
    private ViewScorePoints _viewScore;
    private ViewScoreLine _viewScoreLine;
    private ViewSwapFigure _viewSwapFigure;
    private ButtonPauseGame _buttonPauseGame;
    private ButtonSoundControl _buttonSoundControl;

    protected override void GetComponents() {
        _viewScore = GetComponentInChildren<ViewScorePoints>();
        _viewScoreLine = GetComponentInChildren<ViewScoreLine>();
        _viewSwapFigure = GetComponentInChildren<ViewSwapFigure>();
        _buttonPauseGame = GetComponentInChildren<ButtonPauseGame>();
        _buttonSoundControl = GetComponentInChildren<ButtonSoundControl>();
    }

    protected override void InitializeComponents() {
        _viewScore.Initialize(EventBus);
        _viewScoreLine.Initialize(EventBus);
        _viewSwapFigure.Initialize(EventBus);
        _buttonPauseGame.Initialize(EventBus);
        _buttonSoundControl.Initialize(EventBus);
    }

    public void Dispose() {
        _viewSwapFigure.Dispose();
        _viewScoreLine.Dispose();
        _viewScore.Dispose();
    }
}