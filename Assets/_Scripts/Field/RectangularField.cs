using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RectangularField : Field {
    private const int BEGIN_BOARDER_FIELD = -1;
    private int countCurrentDeleteLine;

    private int _hieght;
    private int _width;

    public RectangularField(Cell[][] cells) : base(cells) {
        AssignValue(cells);
    }

    public override bool ICanMoveHere(IEnumerable<Vector3Int> positionCellsFigure) {
        foreach (var cell in positionCellsFigure) {
            if (IsOccupiedCell(cell))
                return false;
        }
        return true;
    }

    public override void ShowNewCells(IEnumerable<Vector3Int> newPositionCells, IEnumerable<Vector3Int> oldPositionCells, Color colorCell) {
        HideCells(oldPositionCells);
        ShowCells(newPositionCells, colorCell);
    }

    public override void ShowNewCellsGhost(IEnumerable<Vector3Int> newPositionCells) {
        HideCellsGhost();
        ShowCellsGhost(newPositionCells);
    }

    public override void CheckFillLines() {
        countCurrentDeleteLine = 0;
        for (int i = Cells.GetLength(0) - 1; i >= 0 ; i--) {
            if (Cells[i].All(cell => cell.IsVisible)) {
                DeleteLine(i);
                countCurrentDeleteLine++;
            }
        }
        if (countCurrentDeleteLine > 0) {
            UpdateData();
            SendData();
        }
    }

    protected override void UpdateData() {
        CountDeleteLine += countCurrentDeleteLine;
        Score += Mathematics.Pow(countCurrentDeleteLine);
    }

    protected override void SendData() {
        _eventBus.Invoke(new ChangedCountDeleteLineSignal(CountDeleteLine));
        _eventBus.Invoke(new ChangedScoreSignal(Score));
    }

    private void AssignValue(Cell[][] field) {
        _hieght = field.Length;
        _width = field[0].Length;
    }

    private bool IsOccupiedCell(Vector3Int cell) {
        if (IsBoarder(cell)) {
            return true;
        } else if (IsOtherCellFigure(cell)) {
            return true;
        }

        return false;
    }

    private void HideCells(IEnumerable<Vector3Int> currentPositionFigures) {
        foreach (var cell in currentPositionFigures) {
            HideCell(cell);
        }
    }

    private void ShowCells(IEnumerable<Vector3Int> currentPositionFigures, Color colorCell) {
        foreach (var cell in currentPositionFigures) {
            ShowCell(cell, colorCell);
        }
    }

    private void DeleteLine(int idLine) {
        HideLine(idLine);
        RedrawField(idLine);
    }

    private void RedrawField(int idLine) {
        for (int y = idLine + 1; y < _hieght; y++) {
            for (int x = 0; x < _width; x++) {
                if (Cells[y][x].IsVisible) {
                    Cells[y][x].Hide();
                    Cells[y - 1][x].Show(Cells[y][x].Color);
                }
            }
        }
    }

    private void HideLine(int idLine) {
        for (int x = 0; x < _width; x++) {
            Cells[idLine][x].Hide(true);
        }
    }

    private void HideCellsGhost() {
        foreach (var arrayCell in Cells) {
            foreach (var cell in arrayCell) {
                cell.HideGhost();
            }
        }
    }

    private bool IsBoarder(Vector3Int cell) {
        return cell.x <= BEGIN_BOARDER_FIELD || cell.x >= _width
            || cell.y <= BEGIN_BOARDER_FIELD || cell.y >= _hieght;
    }

    private bool IsOtherCellFigure(Vector3Int cell) {
        return Cells[cell.y][cell.x].IsVisible;
    }

    private void ShowCell(Vector3Int cell, Color colorCell) {
        Cells[cell.y][cell.x].Show(colorCell);
    }

    private void HideCell(Vector3Int cell) {
        Cells[cell.y][cell.x].Hide();
    }

    private void ShowCellsGhost(IEnumerable<Vector3Int> currentPositionFigures) {
        foreach (var cell in currentPositionFigures) {
            ShowCellGhost(cell);
        }
    }

    private void ShowCellGhost(Vector3Int cell) {
        Cells[cell.y][cell.x].ShowGhost();
    }
}