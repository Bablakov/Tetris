using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FigureSpawner : IService {
    private const string WAY_CONFIG = "FigureConfigs";

    private List<Figure> _figuresSpawnAdvance;
    private FigureConfigs configFigures;
    private Vector3Int _positionSpawn;
    private EventBus _eventBus;

    public FigureSpawner() {
    }

    public void Initialize(Vector3Int positionSpawn) {
        AssignValue(positionSpawn);
        GetComponents();
        Subscribe();
        SpawnNewFigureAdvance();
    }

    private void Subscribe() {
        _eventBus.Subscribe<PutFigureSignal>(SpawnNewFigure);
    }

    private void Unsubscribe() {
        _eventBus.Unsubscribe<PutFigureSignal>(SpawnNewFigure);
    }

    private void AssignValue(Vector3Int positionSpawn) {
        _positionSpawn = positionSpawn;
        _figuresSpawnAdvance = new List<Figure>();
    }

    private void GetComponents() {
        configFigures = Resources.Load<FigureConfigs>(WAY_CONFIG);
        _eventBus = ServiceLocator.Current.Get<EventBus>();
    }

    private void SpawnNewFigureAdvance() {
        for (int i = 0; i < 5; i++) {
            var rnd = Random.Range(0, configFigures.Count);
            var figure = new Figure(configFigures.Configs[rnd], _positionSpawn, _eventBus);
            _figuresSpawnAdvance.Add(figure);
            Debug.Log(figure.MaterialCells.name);
        }
        _eventBus.Invoke(new SpawnedFigureSignal(_figuresSpawnAdvance.First()));
        _figuresSpawnAdvance.RemoveAt(0);
    }

    private void SpawnNewFigure(PutFigureSignal putFigureSignal) {
        var figures = _figuresSpawnAdvance.First();
        _figuresSpawnAdvance.Remove(figures);

        var rnd = Random.Range(0, configFigures.Count);
        
        var figure = new Figure(configFigures.Configs[rnd], _positionSpawn, _eventBus);

        _figuresSpawnAdvance.Add(figure);
        Debug.Log(figure.MaterialCells.name);
        _eventBus.Invoke(new SpawnedFigureSignal(figures));
    }
}