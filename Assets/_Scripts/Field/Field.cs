using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public abstract class Field {
    protected Cell[][] Cells;
    protected EventBus _eventBus;
    protected int CountDeleteLine;

    public Field(Cell[][] cells) {
        Cells = cells;
        _eventBus = ServiceLocator.Current.Get<EventBus>();
    }

    public abstract bool ICanMoveHere(IEnumerable<Vector3Int> positionCellsFigure);
    public abstract void ShowNewCells(IEnumerable<Vector3Int> newPositionCells, IEnumerable<Vector3Int> oldPositionCells, Material materialeCell);

    public abstract void ShowNewCellsGhost(IEnumerable<Vector3Int> newPositionCells);

    public abstract void CheckFillLines();

    protected abstract void UpdateData();

    protected void SendData() {
        _eventBus.Invoke(new DeleteLineSignal(CountDeleteLine));
    }
}