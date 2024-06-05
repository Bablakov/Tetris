using TMPro;
using UnityEngine;

public class ButtonExitGame : HidingButton {
    public override void Initialize(EventBus eventBus) {
        base.Initialize(eventBus);
        
        AddMethodInEventClick(ExitGame);
        AddEventOnButton();
    }

    private void ExitGame() {
        GameSceneController.ExitGame();
    }
}