using TMPro;
using System;
using UnityEngine;

public class ViewScorePoints : MonoBehaviour, IDisposable {
    private const int BEGINNING_VALUE = 0;

    private TextMeshProUGUI _textScore;
    private string _startedText;
    private EventBus _eventBus;

    public void Initialize(EventBus eventBus) {
        _eventBus = eventBus;
        GetComponents();
        SetValue(BEGINNING_VALUE);
        Subscribe();
    }
    private void GetComponents() {
        _textScore = GetComponent<TextMeshProUGUI>();
        _startedText = _textScore.text + "\n";
    }

    private void Subscribe() {
        _eventBus.Subscribe<ChangedScoreSignal>(OnChangegScore);
    }

    private void Unsubscribe() {
        _eventBus.Unsubscribe<ChangedScoreSignal>(OnChangegScore);
    }

    private void OnChangegScore(ChangedScoreSignal signal) {
        SetValue(signal.Score);
    }

    private void SetValue(int value) {
        _textScore.text = _startedText + value;
    }

    public void Dispose() {
        Unsubscribe();
    }
}