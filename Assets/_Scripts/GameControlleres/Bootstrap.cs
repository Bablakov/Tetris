using System;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour {
    [SerializeField] private FieldSpawner spawnerField;
    [SerializeField] private UIController UIController;
    [SerializeField] private InputGame inputGame;

    private const string WAY_FIELD_CONFIG = "FieldConfig";
    private const string WAY_GAME_CONFIG = "GameConfig";

    private FigureGhostController _figureGhostController;
    private FigureController _figureController;
    private FieldController _fieldController;
    private List<IDisposable> _disposables;
    private FigureSpawner _figureSpawner;
    private FieldConfig _fieldConfig;
    private GameConfig _gameConfig;
    private EventBus _eventBus;
    private Field _field;
    

    private void Awake() {
        CreateComponent();
        _fieldConfig = Resources.Load<FieldConfig>(WAY_FIELD_CONFIG);
        _gameConfig = Resources.Load<GameConfig>(WAY_GAME_CONFIG);
        RegisterServices();
        Initialize();
    }

    private void CreateComponent() {
        _figureGhostController = new FigureGhostController();
        _figureController = new FigureController();
        _fieldController = new FieldController();
        _figureSpawner = new FigureSpawner();
        _eventBus = new EventBus();

        ServiceLocator.Initialize();
    }

    private void RegisterServices() {
        ServiceLocator.Current.Register(spawnerField);
        ServiceLocator.Current.Register(_fieldController);
        ServiceLocator.Current.Register(_figureController);
        ServiceLocator.Current.Register(inputGame);
        ServiceLocator.Current.Register(_figureGhostController);
        ServiceLocator.Current.Register(_eventBus);
    }

    private void Initialize() {
        UIController.Initialize();
        _field = spawnerField.Spawn(_fieldConfig);
        _fieldController.Initialize(_field);
        _figureGhostController.Initialize();
        _figureController.Initialize(_gameConfig.SpeedFigure);
        _figureSpawner.Initialize(_fieldConfig.PositionSpawn);
    }

    private void Update() {
        _figureController.MoveDown();
    }
    /*
        private void OnDestroy() {
            foreach (var disposable in _disposables) {
                disposable.Dispose();
            }
        }*/
}