using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ButtonResumeGame : HidingButton {
    public override void Initialize(EventBus eventBus) {
        base.Initialize(eventBus);

        AddMethodInEventClick(ResumeGame);
        AddEventOnButton();

        Hide();
    }

    private void ResumeGame() {
        Hide();
        EventBus.Invoke(new ResumedGameSignal());
    }
}