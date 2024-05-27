using System.Collections.Generic;
using UnityEngine;

public class Figure {
    private readonly IReadOnlyList<FigureShape> _rotateFigure;
    private readonly Material _materialCell;
    private readonly Cell _cell;
    private int _currentRotateFigure;
    private EventBus _eventBus;
    private int CurrentRotateFigure {
        get { return _currentRotateFigure; }
        set {
            if (value >= _rotateFigure.Count)
                _currentRotateFigure = 0;
            else {
                _currentRotateFigure = value;
            }
        }
    }

    public Vector3Int Position { get; private set; }
    public FigureShape PositionCells => _rotateFigure[_currentRotateFigure];
    public FigureShape NextPositionRotateCells => _rotateFigure[(_currentRotateFigure + 1) % _rotateFigure.Count];
    public Material MaterialCells => _materialCell;

    public Figure(FigureConfig figureConfig, Vector3Int startPosition, EventBus eventBus) {
        _rotateFigure = figureConfig.RotateFigure;
        _materialCell = figureConfig.MaterialCell;
        _cell = figureConfig.Cell;
        Position = startPosition;
        _currentRotateFigure = 0;
        _eventBus = ServiceLocator.Current.Get<EventBus>();
    }

    public void SetPosition(Vector3Int position) {
        Position = position;
        _eventBus.Invoke(new ChangedPropertyFigureSignal());
    }

    public void SetNextPositionRotate() {
        CurrentRotateFigure += 1;
        _eventBus.Invoke(new ChangedPropertyFigureSignal());
    }
}