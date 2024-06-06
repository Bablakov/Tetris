using Cinemachine;
using UnityEngine;
using YG;

public class BootstrapGame : Bootstrap {
    [SerializeField] private FieldSpawner spawnerField;
    [SerializeField] private InputGame inputGame;

    private const string WAY_FIELD_CONFIG = "FieldConfig";
    private const string WAY_GAME_CONFIG = "GameConfig";

    private FigureGhostController _figureGhostController;
    private GameTimeController _gameTimeController;
    private FigureController _figureController;
    private FieldController _fieldController;
    private FigureSpawner _figureSpawner;
    private FieldConfig _fieldConfig;
    private GameConfig _gameConfig;
    private Field _field;

    protected override void Awake() {
        YandexGame.LoadProgress();
        base.Awake();
    }

    protected override void GetComponents() {
        _fieldConfig = Resources.Load<FieldConfig>(WAY_FIELD_CONFIG);
        _gameConfig = Resources.Load<GameConfig>(WAY_GAME_CONFIG);
    }

    protected override void CreateComponent() {
        base.CreateComponent();
        _figureController = gameObject.AddComponent<FigureController>();
        _figureGhostController = new FigureGhostController();
        _fieldController = new FieldController();
        _figureSpawner = new FigureSpawner();
        _gameTimeController = new GameTimeController(BusEvent);
    }

    protected override void RegisterServices() {
        base.RegisterServices();
        ServiceLocator.Current.Register(spawnerField);
        ServiceLocator.Current.Register(_fieldController);
        ServiceLocator.Current.Register(inputGame);
    }

    protected override void AddAllIDisposableElementInCollection() {
        base.AddAllIDisposableElementInCollection();
        AddIDisposable(inputGame);
        AddIDisposable(spawnerField);
        AddIDisposable(_figureGhostController);
        AddIDisposable(_gameTimeController);
        AddIDisposable(_figureController);
        AddIDisposable(_fieldController);
        AddIDisposable(_figureSpawner);
        AddIDisposable(_field);
    }

    protected override void Initialize() {
        base.Initialize();
        inputGame.Initialize();
        _field = spawnerField.Spawn(_fieldConfig);
        _figureController.Initialize(_gameConfig.SpeedFigure);
        _fieldController.Initialize(_field);
        _figureGhostController.Initialize();
        _figureSpawner.Initialize(_fieldConfig.PositionSpawn);
        Time.timeScale = 1;
    }
}