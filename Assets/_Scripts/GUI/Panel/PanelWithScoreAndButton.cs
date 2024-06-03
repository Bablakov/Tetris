using System;
using UnityEngine;

public class PanelWithScoreAndButton : MonoBehaviour, IDisposable {
    private EventBus _eventBus;
    private ViewScorePoints _viewScore;
    private ViewScoreLine _viewScoreLine;
    private ViewSwapFigure _viewSwapFigure;
    private ButtonPauseGame _buttonPauseGame;
    private ButtonSoundControl _buttonSoundControl;

    public void Initialize(EventBus eventBus) {
        _eventBus = eventBus;
        GetComponents();
        InitializeComponents();
    }

    private void GetComponents() {
        _viewScore = GetComponentInChildren<ViewScorePoints>();
        _viewScoreLine = GetComponentInChildren<ViewScoreLine>();
        _viewSwapFigure = GetComponentInChildren<ViewSwapFigure>();
        _buttonPauseGame = GetComponentInChildren<ButtonPauseGame>();
        _buttonSoundControl = GetComponentInChildren<ButtonSoundControl>();
    }

    private void InitializeComponents() {
        _viewScore.Initialize(_eventBus);
        _viewScoreLine.Initialize(_eventBus);
        _viewSwapFigure.Initialize(_eventBus);
        _buttonPauseGame.Initialize(_eventBus);
        _buttonSoundControl.Initialize(_eventBus);
    }

    public void Dispose() {
        _viewSwapFigure.Dispose();
        _viewScoreLine.Dispose();
        _viewScore.Dispose();
    }
}