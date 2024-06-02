using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BaseButton : MonoBehaviour{
    protected EventBus EventBusMe;
    
    private Button _button;
    private UnityAction _buttonClickEvent;

    public virtual void Initialize(EventBus eventBus) {
        EventBusMe = eventBus;
        _button = GetComponent<Button>();
        AddMethodInEventClick(ClickOnButton);
    }

    public virtual void Initialize() {
        _button = GetComponent<Button>();
    }

    protected void AddMethodInEventClick(UnityAction action) {
        _buttonClickEvent += action;
    }

    protected void AddEventOnButton() {
        _button.onClick.AddListener(_buttonClickEvent);
    }

    private void ClickOnButton() {
        EventBusMe.Invoke(new ClickedButtonSignal());
    }
}