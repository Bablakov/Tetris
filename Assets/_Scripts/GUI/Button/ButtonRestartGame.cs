using TMPro;
using UnityEngine.SceneManagement;

public class ButtonRestartGame : HidingButton {
    public override void Initialize(EventBus eventBus) {
        base.Initialize(eventBus);

        AddMethodInEventClick(RestartGame);
        AddEventOnButton();
    }
    private void RestartGame() {
        GameSceneController.RestartScene();
    }
}