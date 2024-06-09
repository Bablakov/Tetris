using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class Field {
    protected Cell[][] Cells;
    protected EventBus _eventBus;
    protected int CountDeleteLine;
    protected int Score;

    public Field(Cell[][] cells) {
        Cells = cells;
        _eventBus = ServiceLocator.Current.Get<EventBus>();
    }

    public abstract bool ICanMoveHere(IEnumerable<Vector3Int> positionCellsFigure);
    public abstract void ShowNewCells(IEnumerable<Vector3Int> newPositionCells, IEnumerable<Vector3Int> oldPositionCells, Color colorCell);

    public abstract void ShowNewCellsGhost(IEnumerable<Vector3Int> newPositionCells);

    public abstract void CheckFillLines();

    protected abstract void UpdateData();

    protected abstract void SendData();
}