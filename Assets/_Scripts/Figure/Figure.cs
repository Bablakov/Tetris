using System.Collections.Generic;
using UnityEngine;

public class Figure {
    private readonly IReadOnlyList<FigureShape> _rotateFigure;
    private readonly Material _materialCell;
    private readonly Cell _cell;
    private int _currentRotateFigure;
    private Sprite _spriteFigure;
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
    public Sprite SpriteFigure => _spriteFigure;

    public Figure(FigureConfig figureConfig, Vector3Int startPosition, EventBus eventBus) {
        _rotateFigure = figureConfig.RotateFigure;
        _materialCell = figureConfig.MaterialCell;
        _cell = figureConfig.Cell;
        _spriteFigure = figureConfig.SpriteFigure;
        Position = startPosition;
        _currentRotateFigure = 0;
        
        _eventBus = eventBus;
    }

    public void SetPosition(Vector3Int position) {
        var oldPosition = Position;
        Position = position;
        if (oldPosition.x != Position.x)
            _eventBus.Invoke(new ChangedPropertyFigureSignal());
    }

    public void SetNextPositionRotate() {
        CurrentRotateFigure += 1;
        _eventBus.Invoke(new ChangedPropertyFigureSignal(true));
    }
}