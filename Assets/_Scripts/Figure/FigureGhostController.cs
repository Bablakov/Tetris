using System.Collections.Generic;
using UnityEngine;

public class FigureGhostController: IService {
    private readonly Vector3Int Down = new Vector3Int(0, -1, 0);
    
    private IEnumerable<Vector3Int> Cells => _figure.PositionCells.Cells;
    private Vector3Int Position => _figure.Position;
    
    private FieldController _fieldController;
    private Vector3Int position;
    private EventBus _eventBus;
    private Figure _figure;

    public FigureGhostController() {
    }

    public void Initialize() {
        GetComponents();
        Subscribe();
    }

    private void GetComponents() {
        _fieldController = ServiceLocator.Current.Get<FieldController>();
        _eventBus = ServiceLocator.Current.Get<EventBus>();
    }

    private void Subscribe() {
        _eventBus.Subscribe<SpawnedFigureSignal>(OnSpawnedFigure);
        _eventBus.Subscribe<ChangedPropertyFigureSignal>(OnChangedPropertyFigure);
    }

    private void Unsubscribe() {
        _eventBus.Unsubscribe<SpawnedFigureSignal>(OnSpawnedFigure);
        _eventBus.Unsubscribe<ChangedPropertyFigureSignal>(OnChangedPropertyFigure);
    }

    private void OnSpawnedFigure(SpawnedFigureSignal spawnedFigureSignal) {
        AssignValue(spawnedFigureSignal);
        CalculateCurrentPositionCells();
        OnChangedPropertyFigure();
    }

    private void OnChangedPropertyFigure() {
        position = Position;
        while (IsCanMove(Down)) {
            UpdateDataMove(Down);
        }
        Move();
    }

    private void OnChangedPropertyFigure(ChangedPropertyFigureSignal changedPropertyFigureSignal) {
        position = Position;
        while (IsCanMove(Down)) {
            UpdateDataMove(Down);
        }
        Move();
    }

    private void AssignValue(SpawnedFigureSignal spawnedFigureSignal) {
        _figure = spawnedFigureSignal.Figure;
        position = Position;
    }

    private bool IsCanMove(Vector3Int moveDirection) {
        return _fieldController.ICanMoveHere(FindUniqueCellPosition(position + moveDirection));
    }

    private void Move() {
        _fieldController.ShowNewCellsGhost(CalculatePositionCells(position, Cells));
    }

    private void UpdateDataMove(Vector3Int moveDirection) {
        position += moveDirection;
    }

    private IEnumerable<Vector3Int> CalculatePositionCells(Vector3Int value, IEnumerable<Vector3Int> cells) {
        return Mathematics.CalculatePositionCells(value, cells);
    }

    private IEnumerable<Vector3Int> FindUniqueCellPosition(Vector3Int newPosition) {
        return Mathematics.FindUniqueCellPosition(Position, newPosition, Cells);
    }

    private IEnumerable<Vector3Int> CalculateCurrentPositionCells() {
        return Mathematics.CalculatePositionCells(Position, Cells);
    }
}