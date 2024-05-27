using UnityEngine;

public class WantedMoveHereSignal {
    public readonly Vector3Int NewPosition;
    public readonly Vector3Int[] CurrentCellsPosition;
    public readonly Vector3Int[] NewCellsPositionWithoutRepetition;

    public WantedMoveHereSignal(Vector3Int newPosition, 
        Vector3Int[] currentCellsPosition, Vector3Int[] newCellsPositionWithoutRepetition) {
        NewPosition = newPosition;
        CurrentCellsPosition = currentCellsPosition;
        NewCellsPositionWithoutRepetition = newCellsPositionWithoutRepetition;
    }
}