using System;
using Unity.VisualScripting;
using UnityEngine.SocialPlatforms.Impl;
using YG;

public class GameDataController: IDisposable {
    private const string NAME_LIDERBOARD_WITH_SCORE = "LBScore";

    private EventBus _eventBus;
    private int _countDeleteLine;
    private int _score;

    public GameDataController(EventBus eventBus) {
        _eventBus = eventBus;
        Subscribe();
    }

    private void Subscribe() {
        _eventBus.Subscribe<ChangedCountDeleteLineSignal>(OnChangedCountDeleteLine);
        _eventBus.Subscribe<ChangedScoreSignal>(OnChangedScore);
        _eventBus.Subscribe<FinishedGameSignal>(SendDataFinished);
    }

    private void Unsubscribe() {
        _eventBus.Unsubscribe<ChangedCountDeleteLineSignal>(OnChangedCountDeleteLine);
        _eventBus.Unsubscribe<ChangedScoreSignal>(OnChangedScore);
        _eventBus.Unsubscribe<FinishedGameSignal>(SendDataFinished);
    }

    private void OnChangedCountDeleteLine(ChangedCountDeleteLineSignal signal) {
        _countDeleteLine = signal.Score;
    }

    private void OnChangedScore(ChangedScoreSignal signal) {
        _score = signal.Score;
    }

    private void SendDataFinished(FinishedGameSignal signal) {
        LoadSavedData();
        SendDataScoreLine();
        SendDataScorePoints();
    }

    private static void LoadSavedData() {
        YandexGame.LoadProgress();
    }

    private void SendDataScoreLine() {
        if (YandexGame.savesData.bestScoreLine < _countDeleteLine) {
            YandexGame.savesData.bestScoreLine = _countDeleteLine;
            YandexGame.SaveProgress();
            _eventBus.Invoke<FinishedScoreLineSignal>(new(_countDeleteLine, _countDeleteLine));
        } 
        else {
            _eventBus.Invoke<FinishedScoreLineSignal>(new(YandexGame.savesData.bestScoreLine, _countDeleteLine));
        }
    }

    private void SendDataScorePoints() {
        if (YandexGame.savesData.bestScorePoints < _score) {
            YandexGame.savesData.bestScorePoints = _score;
            YandexGame.SaveProgress();
            YandexGame.NewLeaderboardScores(NAME_LIDERBOARD_WITH_SCORE, _score);
            _eventBus.Invoke<FinishedScoreSignal>(new(_score, _score));
        } 
        else {
            _eventBus.Invoke<FinishedScoreSignal>(new(YandexGame.savesData.bestScorePoints, _score));
        }
    }

    public void Dispose() {
        Unsubscribe();
    }
}