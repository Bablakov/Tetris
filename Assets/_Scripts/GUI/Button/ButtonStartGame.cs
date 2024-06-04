using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonStartGame : StandartButton {
    public override void Initialize(EventBus eventBus) {
        base.Initialize(eventBus);

        AddMethodInEventClick(LoadGameScene);
        AddEventOnButton();
    }

    private void LoadGameScene() {
        SceneManager.LoadScene("Game");
    }
}