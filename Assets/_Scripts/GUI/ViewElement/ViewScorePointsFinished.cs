using TMPro;
using UnityEngine;

public class ViewScorePointsFinished : MonoBehaviour {
    private const string DEFAULT_STRING = "Score: ";

    private TextMeshProUGUI _textScore;
    private EventBus _eventBus;

    public void Initialize(EventBus eventBus) {
        _eventBus = eventBus;
        GetComponents();
        Subscribe();
    }

    public void Show() {
        _textScore.enabled = true;
    }

    public void Hide() {
        _textScore.enabled = false;
    }

    private void GetComponents() {
        _textScore = GetComponent<TextMeshProUGUI>();
    }

    private void Subscribe() {
        _eventBus.Subscribe<FinishedScoreSignal>(OnChangegScore);
    }

    private void Unsubscribe() {
        _eventBus.Unsubscribe<FinishedScoreSignal> (OnChangegScore);
    }

    private void OnChangegScore(FinishedScoreSignal signal) {
        SetValue(signal.ScoreFinished);
    }

    private void SetValue(int value) {
        _textScore.text = DEFAULT_STRING + value;
    }

    public void Dispose() {
        Unsubscribe();
    }
}