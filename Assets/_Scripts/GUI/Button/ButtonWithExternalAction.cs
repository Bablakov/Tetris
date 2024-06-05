using TMPro;
using UnityEngine.Events;

public class ButtonWithExternalAction : HidingButton {
    public void Initialize(EventBus eventBus, UnityAction actionExitPanel) {
        base.Initialize(eventBus);

        AddMethodInEventClick(actionExitPanel);
        AddEventOnButton();
    }
}