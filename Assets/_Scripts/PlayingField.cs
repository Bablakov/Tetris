using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayingField : MonoBehaviour {
    public static PlayingField instance;

    [SerializeField] private Figure figure;
    [SerializeField] private Cell cell;
    [SerializeField, Range(10, 100, order = 1)] private int hieght;
    [SerializeField, Range(10, 100, order = 1)] private int wieght;

    private const int BEGIN_BOARDER_FIELD = -1;

    private Cell[][] _areaCells;


    public void Initialize() {
        instance = this;
        SpawnField();
    }

    public bool ICanMoveHere(IEnumerable<Vector3Int> positionCellsFigure) {
        foreach (var cell in positionCellsFigure) {
            if (IsOccupiedCell(cell))
                return false;
        }
        return true;
    }

    public void ShowFigure(IEnumerable<Vector3Int> newPositionCells) {
        foreach(var cell in newPositionCells) {
            ShowCell(cell);
        }
    }

    public void ShowFigure(IEnumerable<Vector3Int> newPositionCells, IEnumerable<Vector3Int> oldPositionCells) {
        HideOldFigure(oldPositionCells);
        ShowFigure(newPositionCells);
    }

    private void SpawnField() {
        _areaCells = new Cell[hieght][];
        for (int y = 0; y < hieght; y++) {
            _areaCells[y] = new Cell[wieght];
            for (int x = 0; x < wieght; x++) {
                SpawnCellAndSave(y, x);
            }
        }
    }

    private void SpawnCellAndSave(int y, int x) {
        _areaCells[y][x] = Instantiate(cell, new Vector3Int(x, y, 0), Quaternion.identity);
    }

    private void HideOldFigure(IEnumerable<Vector3Int> currentPositionFigures) {
        foreach (var c in currentPositionFigures) {
            HideCell(c);
        }
    }

    private void ShowCell(Vector3Int cell) {
        _areaCells[cell.y][cell.x].Show();
    }

    private void HideCell(Vector3Int cell) {
        _areaCells[cell.y][cell.x].Hide();
    }

    private bool IsOccupiedCell(Vector3Int cell) {
        if (IsBoarder(cell))
            return true;
        if (IsOtherCellFigure(cell))
            return true;

        return false;
    }

    private bool IsBoarder(Vector3Int cell) {
        return cell.x <= BEGIN_BOARDER_FIELD || cell.x >= wieght 
            || cell.y <= BEGIN_BOARDER_FIELD || cell.y >= hieght;
    }

    private bool IsOtherCellFigure(Vector3Int cell) {
        return _areaCells[cell.y][cell.x].IsVisible();
    }
}