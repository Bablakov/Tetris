using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FieldController : MonoBehaviour {
    private const int BEGIN_BOARDER_FIELD = -1;
    
    private Cell[][] _field;
    private int _hieght;
    private int _width;

    public void Initialize(Cell[][] field) {
        _field = field;
        _width = field[0].Length;
        _hieght = field.GetLength(0);
    }

    public bool ICanMoveHere(IEnumerable<Vector3Int> positionCellsFigure) {
        foreach (var cell in positionCellsFigure) {
            if (IsOccupiedCell(cell))
                return false;
        }
        return true;
    }

    public void ShowNewFigure(IEnumerable<Vector3Int> newPositionCells, IEnumerable<Vector3Int> oldPositionCells, Material materialeCell) {
        HideFigure(oldPositionCells);
        ShowFigure(newPositionCells, materialeCell);
    }

    public void ShowNewFigureGhost(IEnumerable<Vector3Int> newPositionCells) {
        HideFigureGhost();
        ShowFigureGhost(newPositionCells);
    }

    public void CheckFillLines() {
        for (int i = 0; i < _field.GetLength(0); i++) {
            if (_field[i].All(cell => cell.IsVisible())) {
                DeleteLine(i);
                i = -1; // нужно для того, чтобы заново проходили массив массивов и не оставили заполненых строк
            }
        }
    }

    private void DeleteLine(int idLine) {
        for (int x = 0; x < _width; x++) {
            _field[idLine][x].Hide();
        }

        for (int y = idLine + 1; y < _hieght; y++) {
            for (int x = 0; x < _width; x++) {
                if (_field[y][x].IsVisible()) {
                    _field[y][x].Hide();
                    _field[y - 1][x].Show(_field[y][x].Material);
                }
            }
        }
    }

    private void HideFigure(IEnumerable<Vector3Int> currentPositionFigures) {
        foreach (var cell in currentPositionFigures) {
            HideCell(cell);
        }
    }

    private void HideFigureGhost() {
        foreach (var arrayCell in _field) {
            foreach (var cell in arrayCell) {
                cell.HideGhost();
            }
        }
    }

    private void ShowFigure(IEnumerable<Vector3Int> currentPositionFigures, Material materialCell) {
        foreach (var cell in currentPositionFigures) {
            ShowCell(cell, materialCell);
        }
    }

    private void ShowFigureGhost(IEnumerable<Vector3Int> currentPositionFigures) {
        foreach (var cell in currentPositionFigures) {
            ShowCellGhost(cell);
        }
    }

    private void ShowCell(Vector3Int cell, Material materialCell) {
        _field[cell.y][cell.x].Show(materialCell);
    }

    private void ShowCellGhost(Vector3Int cell) {
        _field[cell.y][cell.x].ShowGhost();
    }

    private void HideCell(Vector3Int cell) {
        _field[cell.y][cell.x].Hide();
    }
    
    private void HideCellGhost(Vector3Int cell) {
        _field[cell.y][cell.x].HideGhost();
    }

    private bool IsOccupiedCell(Vector3Int cell) {
        if (IsBoarder(cell)) {
            return true;
        }
        if (IsOtherCellFigure(cell)) {
            return true;
        }

        return false;
    }

    private bool IsBoarder(Vector3Int cell) {
        return cell.x < 0 || cell.x >= _width
            || cell.y < 0 || cell.y >= _hieght;
    }

    private bool IsOtherCellFigure(Vector3Int cell) {
        return _field[cell.y][cell.x].IsVisible();
    }
}