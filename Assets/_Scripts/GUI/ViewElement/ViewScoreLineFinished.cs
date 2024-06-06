using TMPro;
using UnityEngine;

public class ViewScoreLineFinished : MonoBehaviour {
    private TextMeshProUGUI _textScore;
    private string _textStarted;
    private EventBus _eventBus;

    public void Initialize(EventBus eventBus) {
        _eventBus = eventBus;
        GetComponent();
        Subscribe();
    }

    public void Show() {
        _textScore.enabled = true;
    }

    public void Hide() {
        _textScore.enabled = false;
    }

    private void GetComponent() {
        _textScore = GetComponent<TextMeshProUGUI>();
        _textStarted = _textScore.text;
    }

    private void Subscribe() {
        _eventBus.Subscribe<FinishedScoreLineSignal>(OnFinishedScoreLine);
    }

    private void Unsubscribe() {
        _eventBus.Unsubscribe<FinishedScoreLineSignal>(OnFinishedScoreLine);
    }

    private void OnFinishedScoreLine(FinishedScoreLineSignal signal) {
        SetValue(signal.ScoreLineFinished);
    }

    private void SetValue(int value) {
        _textScore.text = _textStarted + value;
    }

    public void Dispose() {
        Unsubscribe();
    }
}