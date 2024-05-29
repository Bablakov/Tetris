using System;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bootstrap : MonoBehaviour {
    [SerializeField] private FieldSpawner spawnerField;
    [SerializeField] private UIController UIController;
    [SerializeField] private InputGame inputGame;

    private const string WAY_FIELD_CONFIG = "FieldConfig";
    private const string WAY_GAME_CONFIG = "GameConfig";

    private FigureGhostController _figureGhostController;
    private FigureController _figureController;
    private FieldController _fieldController;
    private FigureSpawner _figureSpawner;
    private FieldConfig _fieldConfig;
    private GameConfig _gameConfig;
    private EventBus _eventBus;
    private Field _field;

    private List<IDisposable> _disposables;
    
    private void Awake() {
        CreateComponent();
        GetComponents();
        AddAllIDisposableElementInCollection();
        RegisterServices();
        _eventBus.Subscribe<FinishedGameSignal>(OnFinishedGame);
        Initialize();
    }

    private void CreateComponent() {
        _figureController = gameObject.AddComponent<FigureController>();
        _figureGhostController = new FigureGhostController();
        _fieldController = new FieldController();
        _figureSpawner = new FigureSpawner();
        _eventBus = new EventBus();

        ServiceLocator.Initialize();
    }

    private void GetComponents() {
        _fieldConfig = Resources.Load<FieldConfig>(WAY_FIELD_CONFIG);
        _gameConfig = Resources.Load<GameConfig>(WAY_GAME_CONFIG);
    }

    private void RegisterServices() {
        ServiceLocator.Current.Register(spawnerField);
        ServiceLocator.Current.Register(_fieldController);
        ServiceLocator.Current.Register(_figureController);
        ServiceLocator.Current.Register(inputGame);
        ServiceLocator.Current.Register(_figureGhostController);
        ServiceLocator.Current.Register(_eventBus);
    }

    private void AddAllIDisposableElementInCollection() {
        _disposables = new() {
            spawnerField,
            UIController,
            _figureGhostController,
            _figureController,
            _fieldController,
            _figureSpawner
        };
    }

    private void Initialize() {
        UIController.Initialize();
        inputGame.Initialize();
        _field = spawnerField.Spawn(_fieldConfig);
        _figureController.Initialize(_gameConfig.SpeedFigure);
        _fieldController.Initialize(_field);
        _figureGhostController.Initialize();
        _figureSpawner.Initialize(_fieldConfig.PositionSpawn);
    }

    private void OnFinishedGame(FinishedGameSignal siganl) {
        Time.timeScale = 0;
    }

    private void OnDestroy() {
        DestroyAllObject();
    }

    private void DestroyAllObject() {
        foreach (var IDisposableObject in _disposables)
            IDisposableObject.Dispose();
    }
}