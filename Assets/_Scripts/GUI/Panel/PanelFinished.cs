using System;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UI;

public class PanelFinished : MonoBehaviour, IDisposable {
    private ButtonGoMenu _buttonGoMenu;
    private ButtonExitGame _buttonExitGame;
    private ButtonRestartGame _buttonRestartGame;
    private ViewScoreLineFinished _viewScoreLineFinished;
    private ViewScorePointsFinished _viewScorePointsFinished;
    private Image _image;
    private EventBus _eventBus;

    public void Initialize(EventBus eventBus) {
        _eventBus = eventBus;
        GetComponents();
        InitializeComponents();
        HideAllElements();
        Subscribe();
    }

    private void Subscribe() {
        _eventBus.Subscribe<FinishedGameSignal>(ShowAllElements);
    }    

    private void Unsubscribe() {
        _eventBus.Unsubscribe<FinishedGameSignal>(ShowAllElements);
    }

    private void GetComponents() {
        _image = GetComponent<Image>();
        _buttonGoMenu = GetComponentInChildren<ButtonGoMenu>();
        _buttonExitGame = GetComponentInChildren<ButtonExitGame>();
        _buttonRestartGame = GetComponentInChildren<ButtonRestartGame>();
        _viewScoreLineFinished = GetComponentInChildren<ViewScoreLineFinished>();
        _viewScorePointsFinished = GetComponentInChildren<ViewScorePointsFinished>();
    }

    private void InitializeComponents() {
        _buttonGoMenu.Initialize(_eventBus);
        _buttonExitGame.Initialize(_eventBus);
        _buttonRestartGame.Initialize(_eventBus);
        _viewScoreLineFinished.Initialize(_eventBus);
        _viewScorePointsFinished.Initialize(_eventBus);
    }

    private void ShowAllElements(FinishedGameSignal signal) {
        Show();

        _buttonGoMenu.Show();
        _buttonExitGame.Show();
        _buttonRestartGame.Show();
        _viewScoreLineFinished.Show();
        _viewScorePointsFinished.Show();
    }

    private void HideAllElements() {
        Hide();

        _buttonGoMenu.Hide();
        _buttonExitGame.Hide();
        _buttonRestartGame.Hide();
        _viewScoreLineFinished.Hide();
        _viewScorePointsFinished.Hide();
    }

    private void Show() {
        _image.enabled = true;
    }

    private void Hide() {
        _image.enabled = false;
    }

    public void Dispose() {
        Unsubscribe();
    }
}