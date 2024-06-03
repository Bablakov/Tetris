using TMPro;
using UnityEngine.Events;

public class ButtonWithExternalAction : StandartButton {
    private TextMeshProUGUI _text;

    public void Initialize(EventBus eventBus, UnityAction actionExitPanel, string textButton) {
        base.Initialize(eventBus);
        _text = GetComponent<TextMeshProUGUI>();
        _text.text = textButton;
        AddMethodInEventClick(actionExitPanel);
        AddEventOnButton();
    }
}