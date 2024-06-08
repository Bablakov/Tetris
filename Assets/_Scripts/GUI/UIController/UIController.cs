using UnityEngine;

public abstract class UIController : MonoBehaviour {
    protected PanelSettings PanelSettings;
    protected EventBus EventBus;

    public virtual void Initialize() {
        GetComponents();
        InitializeComponents();
    }

    protected virtual void GetComponents() {
        EventBus = ServiceLocator.Current.Get<EventBus>();
        PanelSettings = GetComponentInChildren<PanelSettings>();
    }

    protected virtual void InitializeComponents() {
        PanelSettings.Initialize(EventBus); 
    }
}