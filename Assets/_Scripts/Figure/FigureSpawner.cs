using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FigureSpawner : IService, IDisposable {
    private const string WAY_CONFIG = "FigureConfigs";
    private const int COUNT_FIGURE = 5;

    private Queue<Figure> _createdQueueFigures;
    private FigureConfigs _configFigures;
    private Vector3Int _positionSpawn;
    private EventBus _eventBus;

    public FigureSpawner() {
    }

    public void Initialize(Vector3Int positionSpawn) {
        AssignValue(positionSpawn);
        GetComponents();
        Subscribe();
        CreateQueueFigures();
        SendStartFigure();
    }

    private void Subscribe() {
        _eventBus.Subscribe<PutFigureSignal>(SpawnNewFigure);
    }

    private void Unsubscribe() {
        _eventBus.Unsubscribe<PutFigureSignal>(SpawnNewFigure);
    }

    private void AssignValue(Vector3Int positionSpawn) {
        _positionSpawn = positionSpawn;
        _createdQueueFigures = new();
    }

    private void GetComponents() {
        _configFigures = Resources.Load<FigureConfigs>(WAY_CONFIG);
        _eventBus = ServiceLocator.Current.Get<EventBus>();
    }

    private void CreateQueueFigures() {
        for (int i = 0; i < COUNT_FIGURE; i++) {
            _createdQueueFigures.Enqueue(CreateFigure());
        }
    }

    private void SpawnNewFigure(PutFigureSignal putFigureSignal) {
        _createdQueueFigures.Enqueue(CreateFigure());
        SendFigure();
    }

    private Figure CreateFigure() {
        var rnd = UnityEngine.Random.Range(0, _configFigures.Count);
        var figure = new Figure(_configFigures.Configs[rnd], _positionSpawn, _eventBus);
        return figure;
    }

    private void SendStartFigure() {
        var figures = _createdQueueFigures.Dequeue();
        _eventBus.Invoke(new SpawnedFigureSignal(figures));
        _eventBus.Invoke(new ChangedQueueFigureSignal(_createdQueueFigures));
        _eventBus.Invoke(new CreatedFigureSwapSignal(CreateFigure()));
    }

    private void SendFigure() {
        var figures = _createdQueueFigures.Dequeue();
        _eventBus.Invoke(new SpawnedFigureSignal(figures));
        _eventBus.Invoke(new ChangedQueueFigureSignal(_createdQueueFigures));
    }

    public void Dispose() {
        Unsubscribe();
    }
}