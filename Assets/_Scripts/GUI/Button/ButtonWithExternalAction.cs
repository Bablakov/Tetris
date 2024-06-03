using TMPro;
using UnityEngine.Events;
using UnityEngine.UI;

public class ButtonWithExternalAction : StandartButton {
    private TextMeshProUGUI _text;
    private Image _image;

    public void Initialize(EventBus eventBus, UnityAction actionExitPanel, string textButton) {
        base.Initialize(eventBus);
        _text = GetComponentInChildren<TextMeshProUGUI>();
        _image = GetComponent<Image>();
        _text.text = textButton;
        AddMethodInEventClick(actionExitPanel);
        AddEventOnButton();
    }

    public void Show() {
        _image.enabled = true;
        _text.enabled = true;
    }

    public void Hide() {
        _image.enabled = false;
        _text.enabled = false;
    }
}