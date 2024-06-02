using System;
using TMPro;
using UnityEngine;

public class ViewScoreLine : MonoBehaviour, IDisposable {
    private const string DEFAULT_STRING = "Lines: ";
    private const int BEGINNING_VALUE = 0;

    private TextMeshProUGUI _textScore;
    private EventBus _eventBus;

    public void Initialize(EventBus eventBus) {
        _eventBus = eventBus;
        GetComponent();
        SetValue(BEGINNING_VALUE);
        Subscribe();
    }

    private void GetComponent() {
        _textScore = GetComponent<TextMeshProUGUI>();
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
        _textScore.text = DEFAULT_STRING + value;
    }

    public void Dispose() {
        Unsubscribe();
    }
}