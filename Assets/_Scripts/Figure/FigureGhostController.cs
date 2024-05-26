using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class FigureGhostController {
    private FieldController _fieldController;
    private Figure _figure;

    private Vector3Int position;
    private Vector3Int Position => _figure.Position;
    private IEnumerable<Vector3Int> Cells => _figure.PositionCells.Cells;

    private Vector3Int Down = new Vector3Int(0, -1, 0);
    private IEnumerable<Vector3Int> _newPositionCell;

    public FigureGhostController(FieldController fieldController) {
        _fieldController = fieldController;
    }

    public void SetFigure(Figure figure) {
        if (_figure != null) {
            Unsubscribe();
        }
        _figure = figure;
        position = Position;
        CalculateCurrentPositionCells();
        OnChanged();
        Subscribe();
    }

    private void Subscribe() {
        _figure.Changed += OnChanged;
    }

    private void Unsubscribe() {
        _figure.Changed -= OnChanged;
    }

    private void OnChanged() {
        Debug.Log("OnChanged");
        position = Position;
        while (Move(Down)) {
        }
        _fieldController.ShowNewFigureGhost(CalculatePositionCells(position, Cells));
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