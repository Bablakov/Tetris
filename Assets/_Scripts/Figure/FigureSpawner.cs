using System.Collections.Generic;
using UnityEngine;

public class FigureSpawner : MonoBehaviour, IService {
    [SerializeField] private List<FigureConfig> configFigures;

    private Vector3Int _positionSpawn;
    private EventBus _eventBus;

    public void Initialize(Vector3Int positionSpawn) {
        _positionSpawn = positionSpawn;
        _eventBus = ServiceLocator.Current.Get<EventBus>();
        Subscribe();
        SpawnNewFigure(null);
    }

    public void SpawnNewFigure(PutFigureSignal putFigureSignal) {
        var rnd = Random.Range(0, configFigures.Count);
        
        var figure = new Figure(configFigures[rnd], _positionSpawn, _eventBus);

        _eventBus.Invoke(new SpawnedFigureSignal(figure));
    }

    private void Subscribe() {
        _eventBus.Subscribe<PutFigureSignal>(SpawnNewFigure);
    }

    private void Unsubscribe() {
        _eventBus.Unsubscribe<PutFigureSignal>(SpawnNewFigure);
    }
}