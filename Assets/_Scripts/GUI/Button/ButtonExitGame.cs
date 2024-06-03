using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonExitGame : StandartButton {
    private TextMeshProUGUI _text;
    private Image _image;

    public override void Initialize(EventBus eventBus) {
        base.Initialize(eventBus);
        AddMethodInEventClick(ExitGame);
        AddEventOnButton();
    }

    protected override void GetComponent() {
        base.GetComponent();
        _text = GetComponentInChildren<TextMeshProUGUI>();
        _text.text = "Exit";
        _image = GetComponent<Image>();
    }

    private void ExitGame() {
        Application.Quit();
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