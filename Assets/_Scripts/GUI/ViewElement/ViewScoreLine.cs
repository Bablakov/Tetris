using System;
using TMPro;
using UnityEngine;

public class ViewScoreLine : MonoBehaviour, IDisposable {
    private const int BEGINNING_VALUE = 0;

    private TextMeshProUGUI _textScore;
    private string _startedText;
    private EventBus _eventBus;

    public void Initialize(EventBus eventBus) {
        _eventBus = eventBus;
        GetComponent();
        SetValue(BEGINNING_VALUE);
        Subscribe();
    }

    private void GetComponent() {
        _textScore = GetComponent<TextMeshProUGUI>();
        _startedText = _textScore.text + "\n";
    }

    private void Subscribe() {
        _eventBus.Subscribe<ChangedCountDeleteLineSignal>(OnDeletedCountLine);
    }

    private void Unsubscribe() {
        _eventBus.Unsubscribe<ChangedCountDeleteLineSignal>(OnDeletedCountLine);
    }

    private void OnDeletedCountLine(ChangedCountDeleteLineSignal signal) {
        SetValue(signal.Score);
    }

    private void SetValue(int value) {
        _textScore.text = _startedText + value;
    }

    public void Dispose() {
        Unsubscribe();
    }
}