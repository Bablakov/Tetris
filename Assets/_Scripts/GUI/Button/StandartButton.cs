using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class StandartButton : BaseButton {
    protected EventBus EventBusMe;
    
    private Button _button;
    private UnityAction _buttonClickEvent;

    public override void Initialize(EventBus eventBus) {
        EventBusMe = eventBus;
        _button = GetComponent<Button>();
        AddMethodInEventClick(ClickOnButton);
    }

    protected override void AddMethodInEventClick(UnityAction action) {
        _buttonClickEvent += action;
    }

    protected override void AddEventOnButton() {
        _button.onClick.AddListener(_buttonClickEvent);
    }

    protected override void ClickOnButton() {
        EventBusMe.Invoke(new ClickedButtonSignal());
    }
}