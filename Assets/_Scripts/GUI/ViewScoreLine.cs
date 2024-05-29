using System;
using TMPro;
using UnityEngine;

public class ViewScoreLine : MonoBehaviour, IDisposable {
    private const string DEFAULT_STRING = "Lines: ";

    private TextMeshProUGUI _textScore;
    private EventBus _eventBus;

    public void Initialize(EventBus eventBus) {
        _eventBus = eventBus;
        _textScore = GetComponent<TextMeshProUGUI>();
        _textScore.text = DEFAULT_STRING + 0;
        Subscribe();
    }

    private void Subscribe() {
        _eventBus.Subscribe<DeletedCountLineSignal>(OnDeletedCountLine);
    }

    private void Unsubscribe() {
        _eventBus.Unsubscribe<DeletedCountLineSignal>(OnDeletedCountLine);
    }

    private void OnDeletedCountLine(DeletedCountLineSignal signal) {
        _textScore.text = DEFAULT_STRING + signal.Score;
    }

    public void Dispose() {
        Unsubscribe();
    }
}