using UnityEngine;
using UnityEngine.Events;

public abstract class BaseButton : MonoBehaviour {
    public abstract void Initialize(EventBus eventBus);

    protected abstract void AddMethodInEventClick(UnityAction action);

    protected abstract void AddEventOnButton();
    protected abstract void ClickOnButton();
}