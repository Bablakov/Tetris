using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ButtonPauseGame : BaseButton {
    public override void Initialize(EventBus eventBus) {
        base.Initialize(eventBus);
        CreateButton();
    }

    private void CreateButton() {
        AddMethodInEventClick(PauseGame);
        AddEventOnButton();
    }

    private void PauseGame() {
        EventBusMe.Invoke(new PausedGameSignal());
    }
}