using TMPro;
using UnityEngine.SceneManagement;

public class ButtonGoMenu : HidingButton {
    public override void Initialize(EventBus eventBus) {
        base.Initialize(eventBus);
        AddMethodInEventClick(GoMenu);
        AddEventOnButton();
    }

    private void GoMenu() {
        GameSceneController.GoMenu();
    }
}