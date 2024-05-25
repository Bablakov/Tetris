using System;
using System.Collections.Generic;
using UnityEngine;

public class Figure {
    private readonly List<FigureData> _rotateFigure;
    private readonly Material _materialCell;
    private readonly Cell _cell;
    private int _currentRotateFigure;
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
    public FigureData PositionCells => _rotateFigure[_currentRotateFigure];
    public FigureData NextPositionRotateCells => _rotateFigure[_currentRotateFigure + 1];

    public Figure(List<FigureData> rotateFigure, Material materialCell, Cell cell, Vector3Int spawnPosition) {
        _rotateFigure = rotateFigure;
        _materialCell = materialCell;
        _cell = cell;
        Position = spawnPosition;
        _currentRotateFigure = 0;
    }

    public void SetPosition(Vector3Int position) {
        Position = position;
    }

    public void SetNextPositionRotate() {
        CurrentRotateFigure += 1;
    }
}