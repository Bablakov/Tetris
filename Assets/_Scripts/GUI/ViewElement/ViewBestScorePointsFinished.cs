using UnityEngine;
using TMPro;
using YG;

public class ViewBestScorePointsFinished : MonoBehaviour {
    private const string NAME_LIDERBOARD_WITH_SCORE = "LBScore";

    private TextMeshProUGUI _text;
    private string _startedText;
    private EventBus _eventBus;

    public void Initialize(EventBus eventBus) {
        _eventBus = eventBus;
        GetComponents();
        Subscribe();
    }

    public void Show() {
        _text.enabled = true;
    }

    public void Hide() {
        _text.enabled = false;
    }

    private void GetComponents() {
        _text = GetComponent<TextMeshProUGUI>();
        _startedText = _text.text;
    }

    private void Subscribe() {
        _eventBus.Subscribe<FinishedScoreSignal>(OnChangegScore);
    }

    private void Unsubscribe() {
        _eventBus.Unsubscribe<FinishedScoreSignal>(OnChangegScore);
    }

    private void OnChangegScore(FinishedScoreSignal signal) {
        if (YandexGame.savesData.bestScorePoints < signal.ScoreFinished) {
            SetValue(signal.ScoreFinished);
            YandexGame.savesData.bestScorePoints = signal.ScoreFinished;
            YandexGame.SaveProgress();
            YandexGame.NewLeaderboardScores(NAME_LIDERBOARD_WITH_SCORE, signal.ScoreFinished);
        } 
        else {
            SetValue(YandexGame.savesData.bestScorePoints);
        }
    }

    private void SetValue(int value) {
        _text.text = _startedText + value;
    }

    public void Dispose() {
        Unsubscribe();
    }
}