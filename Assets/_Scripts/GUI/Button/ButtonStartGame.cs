using UnityEngine.SceneManagement;

public class ButtonStartGame : StandartButton {
    public override void Initialize(EventBus eventBus) {
        base.Initialize(eventBus);

        AddMethodInEventClick(LoadGameScene);
        AddEventOnButton();
    }

    private void LoadGameScene() {
        GameSceneController.GoGame();
    }
}