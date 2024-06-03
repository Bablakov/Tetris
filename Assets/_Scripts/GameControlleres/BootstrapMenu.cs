using System;
using System.Collections.Generic;
using UnityEngine;

public class BootstrapMenu : MonoBehaviour {
    [SerializeField] private UIControllerMenu UIControllerMenu;
    [SerializeField] private SoundGame soundGame;

    private EventBus _eventBus;
    private List<IDisposable> _disposables;

    private void Awake() {
        CreateComponent();
        RegisterServices();
        AddAllIDisposableElementInCollection();
        Initialize();
    }
    private void CreateComponent() {
        _eventBus = new EventBus();
        ServiceLocator.Initialize();
    }

    private void RegisterServices() {
        ServiceLocator.Current.Register(_eventBus);
    }

    private void AddAllIDisposableElementInCollection() {
        _disposables = new() {
            soundGame,
            UIControllerMenu,
        };
    }

    private void Initialize() {
        soundGame.Initialize();
        UIControllerMenu.Initialize();
    }

    private void OnDestroy() {
        DestroyAllObject();
    }

    private void DestroyAllObject() {
        foreach (var IDisposableObject in _disposables)
            IDisposableObject.Dispose();
    }
}