using TMPro;
using UnityEngine;

public class ViewScore : MonoBehaviour {
    private TextMeshProUGUI _textScore;
    private EventBus _eventBus;

    public void Initialize(EventBus eventBus) {
        _eventBus = eventBus;
        _textScore = GetComponent<TextMeshProUGUI>();
        _textScore.text = $"Score: {0}";
        Subscribe();
    }

    private void Subscribe() {
        _eventBus.Subscribe<DeleteLineSignal>(OnDeleteLine);
    }

    private void Unsubscribe() {
        _eventBus.Unsubscribe<DeleteLineSignal>(OnDeleteLine);
    }

    private void OnDeleteLine(DeleteLineSignal signal) {
        _textScore.text = $"Score: {signal.Score}";
    }
}