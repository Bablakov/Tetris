using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class Field : IDisposable{
    protected Cell[][] Cells;
    protected EventBus _eventBus;
    protected int CountDeleteLine;
    protected int Score;

    public Field(Cell[][] cells) {
        Cells = cells;
        _eventBus = ServiceLocator.Current.Get<EventBus>();
        Subscribe();
    }

    public abstract bool ICanMoveHere(IEnumerable<Vector3Int> positionCellsFigure);
    public abstract void ShowNewCells(IEnumerable<Vector3Int> newPositionCells, IEnumerable<Vector3Int> oldPositionCells, Material materialeCell);

    public abstract void ShowNewCellsGhost(IEnumerable<Vector3Int> newPositionCells);

    public abstract void CheckFillLines();

    protected abstract void UpdateData();

    protected virtual void Subscribe() {
        _eventBus.Subscribe<FinishedGameSignal>(SendDataFinished);
    }

    protected virtual void Unsubscribe() {
        _eventBus.Unsubscribe<FinishedGameSignal>(SendDataFinished);
    }

    protected virtual void SendData() {
        _eventBus.Invoke(new ChangedCountDeleteLineSignal(CountDeleteLine));
        _eventBus.Invoke(new ChangedScoreSignal(Score));
    }

    protected virtual void SendDataFinished(FinishedGameSignal signal) {
        _eventBus.Invoke<FinishedScoreLineSignal>(new(CountDeleteLine));
        _eventBus.Invoke<FinishedScoreSignal>(new(Score));
    }

    public virtual void Dispose() {
        Unsubscribe();
    }
}