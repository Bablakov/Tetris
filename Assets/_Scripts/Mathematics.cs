using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public static class Mathematics {
    public static IEnumerable<Vector3Int> CalculatePositionCells(Vector3Int value,
        IEnumerable<Vector3Int> cells) {

        var result = cells.Select(cell => cell += value).ToList();
        return result;
    }

    public static IEnumerable<Vector3Int> FindUniqueCellPosition(Vector3Int currentPosition,
        Vector3Int newPosition, IEnumerable<Vector3Int> cells) {

        var currentPositionCell = CalculatePositionCells(currentPosition, cells);
        var newPositionCell = CalculatePositionCells(newPosition, cells);
        var result = newPositionCell.Where(cell => !currentPositionCell.Contains(cell)).ToList();
        return result;
    }

    public static IEnumerable<Vector3Int> FindUniqueCellPosition(Vector3Int position, IEnumerable<Vector3Int> currentCellsPosition, 
        IEnumerable<Vector3Int> newCellsPosition) {

        var currentPositionCell = CalculatePositionCells(position, currentCellsPosition);
        var newPositionCell = CalculatePositionCells(position, newCellsPosition);
        var result = newPositionCell.Where(cell => !currentPositionCell.Contains(cell)).ToList();
        return result;
    }

    public static int Pow(int number) {
        return number * number;
    }
}