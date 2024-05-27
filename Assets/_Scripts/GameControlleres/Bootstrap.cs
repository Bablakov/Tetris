using System;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour {
    [SerializeField] private FieldSpawner spawnerField;
    [SerializeField] private FieldConfig fieldConfig;
    [SerializeField] private FieldController fieldController;
    [SerializeField] private FigureSpawner spawnerFigure;
    [SerializeField] private FigureController figureController;
    [SerializeField] private InputGame inputGame;

    private FigureGhostController _figureGhostController;
    private EventBus _eventBus;
    private List<IDisposable> _disposables;

    private void Awake() {
        CreateComponent();
        RegisterServices();
        Initialize();
    }

    private void CreateComponent() {
        _figureGhostController = new FigureGhostController();
        _eventBus = new EventBus();
        ServiceLocator.Initialize();
    }

    private void RegisterServices() {
        ServiceLocator.Current.Register(spawnerField);
        ServiceLocator.Current.Register(fieldController);
        ServiceLocator.Current.Register(figureController);
        ServiceLocator.Current.Register(inputGame);
        ServiceLocator.Current.Register(_figureGhostController);
        ServiceLocator.Current.Register(_eventBus);
    }

    private void Initialize() {
        fieldController.Initialize(spawnerField.Spawn(fieldConfig));
        _figureGhostController.Initialize();
        figureController.Initialize();
        spawnerFigure.Initialize(fieldConfig.PositionSpawn);
    }
/*
    private void OnDestroy() {
        foreach (var disposable in _disposables) {
            disposable.Dispose();
        }
    }*/
}