using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FigureGhostController: IService {
    private FieldController _fieldController;
    private Figure _figure;

    private Vector3Int position;
    private Vector3Int Position => _figure.Position;
    private IEnumerable<Vector3Int> Cells => _figure.PositionCells.Cells;

    private Vector3Int Down = new Vector3Int(0, -1, 0);
    private IEnumerable<Vector3Int> _newPositionCell;
    private EventBus _eventBus;

    public FigureGhostController() {
    }

    public void Initialize() {
        _fieldController = ServiceLocator.Current.Get<FieldController>();
        _eventBus = ServiceLocator.Current.Get<EventBus>();
        Subscribe();
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
        Debug.Log("Spawned");
        _figure = spawnedFigureSignal.Figure;
        position = Position;
        CalculateCurrentPositionCells();
        OnChangedPropertyFigure();
    }
    
    private void OnChangedPropertyFigure() {
        Debug.Log("Changed");
        position = Position;
        while (Move(Down)) {
        }
        _fieldController.ShowNewCellsGhost(CalculatePositionCells(position, Cells));
    }

    private void OnChangedPropertyFigure(ChangedPropertyFigureSignal changedPropertyFigureSignal) {
        Debug.Log("Changed");
        position = Position;
        while (Move(Down)) {
        }
        _fieldController.ShowNewCellsGhost(CalculatePositionCells(position, Cells));
    }

    private bool Move(Vector3Int moveDirection) {
        if (_fieldController.ICanMoveHere(FindUniqueCellPosition(position + moveDirection))) {
            position += moveDirection;
            return true;
        }
        return false;
    }

    private IEnumerable<Vector3Int> CalculatePositionCells(Vector3Int value, IEnumerable<Vector3Int> cells) {
        var result = cells.Select(cell => cell += value).ToList();
        return result;
    }

    private IEnumerable<Vector3Int> FindUniqueCellPosition(Vector3Int newPosition) {
        _newPositionCell = CalculatePositionCells(newPosition, Cells);
        var result = _newPositionCell.Where(cell => !CalculateCurrentPositionCells().Contains(cell));
        return result;
    }

    private IEnumerable<Vector3Int> FindUniqueCellPosition(IEnumerable<Vector3Int> newCellsPosition) {
        _newPositionCell = CalculatePositionCells(Position, newCellsPosition);
        var result = _newPositionCell.Where(cell => !CalculateCurrentPositionCells().Contains(cell));
        return result;
    }

    private IEnumerable<Vector3Int> CalculateCurrentPositionCells() {
        return CalculatePositionCells(Position, Cells);
    }
}