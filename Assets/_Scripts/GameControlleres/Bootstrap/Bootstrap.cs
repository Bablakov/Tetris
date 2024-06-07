using System.Collections.Generic;
using System;
using UnityEngine;

public abstract class Bootstrap : MonoBehaviour {
    [SerializeField] UIController controllerUI;
    [SerializeField] SoundManager soundGame;

    protected EventBus BusEvent;

    private List<IDisposable> _disposables;

    protected virtual void Start() {
        GetComponents();
        CreateComponent();
        RegisterServices();
        Initialize();
        AddAllIDisposableElementInCollection();
    }

    protected virtual void GetComponents() {
    }

    protected virtual void CreateComponent() {
        _disposables = new List<IDisposable>();
        BusEvent = new EventBus();
        ServiceLocator.Initialize();
    }

    protected virtual void RegisterServices() {
        ServiceLocator.Current.Register(BusEvent);
    }

    protected virtual void AddAllIDisposableElementInCollection() {
        if (controllerUI is IDisposable disposable) {
            AddIDisposable(disposable);
        }
        AddIDisposable(soundGame);
    }

    protected virtual void Initialize() {
        controllerUI.Initialize();
        soundGame.Initialize();
    }

    protected virtual void OnDestroy() {
        DestroyAllObject();
    }

    protected void AddIDisposable(IDisposable idisposable) {
        _disposables.Add(idisposable);
    }

    private void DestroyAllObject() {
        foreach (var IDisposableObject in _disposables)
            IDisposableObject.Dispose();
    }
}