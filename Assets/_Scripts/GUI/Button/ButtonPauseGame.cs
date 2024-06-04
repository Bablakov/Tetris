using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ButtonPauseGame : StandartButton {
    public override void Initialize(EventBus eventBus) {
        base.Initialize(eventBus);

        AddMethodInEventClick(PauseGame);
        AddEventOnButton();
    }

    private void PauseGame() {
        EventBus.Invoke(new PausedGameSignal());
    }
}