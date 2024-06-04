using TMPro;
using UnityEngine;

public class ButtonExitGame : HidingButton {
    private TextMeshProUGUI _text;

    public override void Initialize(EventBus eventBus) {
        base.Initialize(eventBus);
        
        AddMethodInEventClick(ExitGame);
        AddEventOnButton();
        
        SetValue();
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

    private void SetValue() {
        _text.text = "Exit";
    }

    private void ExitGame() {
        GameSceneController.ExitGame();
    }
}