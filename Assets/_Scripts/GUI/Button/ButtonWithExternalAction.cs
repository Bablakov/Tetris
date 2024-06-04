using TMPro;
using UnityEngine.Events;

public class ButtonWithExternalAction : HidingButton {
    private TextMeshProUGUI _text;

    public void Initialize(EventBus eventBus, UnityAction actionExitPanel, string textButton) {
        base.Initialize(eventBus);

        SetValue(textButton);

        AddMethodInEventClick(actionExitPanel);
        AddEventOnButton();
    }

    public override void Show() {
        base.Show();
        _text.enabled = true;
    }

    public override void Hide() {
        base.Hide();
        _text.enabled = false;
    }

    protected override void GetComponents() {
        base.GetComponents();
        _text = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void SetValue(string textButton) {
        _text.text = textButton;
    }
}