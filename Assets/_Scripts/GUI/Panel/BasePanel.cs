using UnityEngine;

public abstract class BasePanel : MonoBehaviour {
    protected EventBus EventBus;

    public virtual void Initialize(EventBus eventBus) {
        EventBus = eventBus;
        GetComponents();
        InitializeComponents();
    }

    protected abstract void GetComponents();
    protected virtual void InitializeComponents() { }
}