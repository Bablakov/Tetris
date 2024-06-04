using System;
using System.Collections.Generic;
using UnityEngine;

public class FieldController : IService, IDisposable {
    private Field _field;
    private EventBus _eventBus;

    public FieldController() {
    }

    public void Initialize(Field field) {
        AssignValue(field);
        GetComponents();
        Subscribe();
    }

    public bool ICanMoveHere(IEnumerable<Vector3Int> positionCellsFigure) {
        return _field.ICanMoveHere(positionCellsFigure);
    }

    public void ShowNewCells(IEnumerable<Vector3Int> newPositionCells, IEnumerable<Vector3Int> oldPositionCells, Material materialeCell) {
        _field.ShowNewCells(newPositionCells, oldPositionCells, materialeCell);
    }

    public void ShowNewCellsGhost(IEnumerable<Vector3Int> newPositionCells) {
        _field.ShowNewCellsGhost(newPositionCells);
    }

    private void CheckFillLines(PutFigureSignal putFigureSignal) {
        _field.CheckFillLines();
    }

    private void GetComponents() {
        _eventBus = ServiceLocator.Current.Get<EventBus>();
    }

    private void AssignValue(Field field) {
        _field = field;
    }

    private void Subscribe() {
        _eventBus.Subscribe<PutFigureSignal>(CheckFillLines);
    }
    
    private void Unsubscribe() {
        _eventBus.Subscribe<PutFigureSignal>(CheckFillLines);
    }

    public void Dispose() {
        Unsubscribe();
    }
}