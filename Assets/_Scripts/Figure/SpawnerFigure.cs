using System.Collections.Generic;
using UnityEngine;

public class SpawnerFigure : MonoBehaviour {
    [SerializeField] private List<FigureConfig> configFigures;

    private FigureGhostController _figureGhostController;
    private FigureController _figureController;
    private Vector3Int _positionSpawn;
    private Figure _figure;

    public void Initialize(Vector3Int positionSpawn, FigureController figureController, FigureGhostController figureGhostController) {
        _figureGhostController = figureGhostController;
        _figureController = figureController;
        _positionSpawn = positionSpawn;
        Subscribe();
        SpawnNewFigure();
    }

    public void SpawnNewFigure() {
        var rnd = Random.Range(0, configFigures.Count);
        _figure = new Figure(configFigures[rnd].RotateFigure, configFigures[rnd].MaterialCell,
            configFigures[rnd].Cell, _positionSpawn);
        _figureController.SetFigure(_figure);
        _figureGhostController.SetFigure(_figure);
    }

    private void Subscribe() {
        _figureController.Stopped += SpawnNewFigure;
    }

    private void Unsubscribe() {
        _figureController.Stopped -= SpawnNewFigure;
    }
}