using TMPro;
using System;
using UnityEngine;

public class ViewScorePoints : MonoBehaviour, IDisposable {
    private const string DEFAULT_STRING = "Score: ";

    private TextMeshProUGUI _textScore;
    private EventBus _eventBus;

    public void Initialize(EventBus eventBus) {
        _eventBus = eventBus;
        _textScore = GetComponent<TextMeshProUGUI>();
        _textScore.text = DEFAULT_STRING + 0;
        Subscribe();
    }

    private void Subscribe() {
        _eventBus.Subscribe<ChangedScoreSignal>(OnChangegScore);
    }

    private void Unsubscribe() {
        _eventBus.Unsubscribe<ChangedScoreSignal>(OnChangegScore);
    }

    private void OnChangegScore(ChangedScoreSignal signal) {
        _textScore.text = DEFAULT_STRING + signal.Score;
    }

    public void Dispose() {
        Unsubscribe();
    }
}