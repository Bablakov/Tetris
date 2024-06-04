using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonRestartGame : HidingButton {
    private TextMeshProUGUI _text;

    public override void Initialize(EventBus eventBus) {
        base.Initialize(eventBus);

        AddMethodInEventClick(RestartGame);
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

    private void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}