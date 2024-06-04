using TMPro;
using UnityEngine.SceneManagement;

public class ButtonGoMenu : HidingButton {
    private TextMeshProUGUI _text;

    public override void Initialize(EventBus eventBus) {
        base.Initialize(eventBus);

        AddMethodInEventClick(GoMenu);
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

    private void GoMenu() {
        GameSceneController.GoMenu();
    }
}