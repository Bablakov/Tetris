using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class FigureController : MonoBehaviour, IService {
    [SerializeField, Range(0.1f, 100f)] private float timeStandart;

    private readonly Vector3Int Down = new Vector3Int(0, -1, 0);
    private readonly Vector3Int Right = new Vector3Int(1, 0, 0);
    private readonly Vector3Int Left = new Vector3Int(-1, 0, 0);

    private float _time = 0.1f;
    private FieldController _fieldController;
    private InputGame _inputGame;
    private EventBus _eventBus;
    private Figure _figure;
    private IEnumerable<Vector3Int> _currentPositionCell;
    private IEnumerable<Vector3Int> _newPositionCell;
    private Vector3Int Position => _figure.Position;
    private IEnumerable<Vector3Int> Cells => _figure.PositionCells.Cells;


    public void Initialize() {
        _inputGame = ServiceLocator.Current.Get<InputGame>();
        _eventBus = ServiceLocator.Current.Get<EventBus>();
        _fieldController = ServiceLocator.Current.Get<FieldController>();
        Subscribe();
    }

    private void Update() {
        if (_time < 0) {
            if (_figure != null) {
                if (!Move(Down)) {
                    _eventBus.Invoke(new PutFigureSignal());
                }
                _time = timeStandart;
            }
        }
        _time -= Time.deltaTime;
    }

    private void Subscribe() {
        _inputGame.InputedLeft += OnInputedLeft;
        _inputGame.InputedRight += OnInputedRight;
        _inputGame.InputedRotate += OnInputedRotate;
        _inputGame.InputedDown += OnInputedDown;
        _inputGame.InputedSpace += OnInputedSpace;
        _eventBus.Subscribe<SpawnedFigureSignal>(OnSpawnedFigureSignal);
    }


    private void Unsubscibe() {
        _inputGame.InputedLeft -= OnInputedLeft;
        _inputGame.InputedRight -= OnInputedRight;
        _inputGame.InputedRotate -= OnInputedRotate;
        _inputGame.InputedDown -= OnInputedDown;
        _inputGame.InputedSpace -= OnInputedSpace;
        _eventBus.Unsubscribe<SpawnedFigureSignal>(OnSpawnedFigureSignal);
    }

    private void OnSpawnedFigureSignal(SpawnedFigureSignal spawnedFigureSignal) {
        _figure = spawnedFigureSignal.Figure;
        CalculateCurrentPositionCells();
    }

    private void OnInputedRotate() {
        if (_fieldController.ICanMoveHere(FindUniqueCellPosition(_figure.NextPositionRotateCells.Cells))) {

            _fieldController.ShowNewCells(CalculatePositionCells(Position, _figure.NextPositionRotateCells.Cells),
                _currentPositionCell, _figure.MaterialCells);

            _figure.SetNextPositionRotate();
            CalculateCurrentPositionCells();
        }
    }

    private void OnInputedRight() {
        Move(Right);
    }

    private void OnInputedLeft() {
        Move(Left);
    }

    private void OnInputedDown() {
        Move(Down);
    }

    private void OnInputedSpace() {
        while (Move(Down)) {
        }
        _eventBus.Invoke(new PutFigureSignal());
    }

    private bool Move(Vector3Int moveDirection) {
        if (_fieldController.ICanMoveHere(FindUniqueCellPosition(Position + moveDirection))) {

            _fieldController.ShowNewCells(CalculatePositionCells(Position + moveDirection, Cells),
                _currentPositionCell, _figure.MaterialCells);

            _figure.SetPosition(Position + moveDirection);
            _currentPositionCell = _newPositionCell;
            return true;
        }
        return false;
    }

    private IEnumerable<Vector3Int> CalculatePositionCells(Vector3Int value, IEnumerable<Vector3Int> cells) {
        var result = cells.Select(cell => cell += value).ToList();
        return result;
    }

    private IEnumerable<Vector3Int> FindUniqueCellPosition(Vector3Int newPosition) {
        _newPositionCell = CalculatePositionCells(newPosition, Cells);
        var result = _newPositionCell.Where(cell => !_currentPositionCell.Contains(cell)).ToList();
        return result;
    }

    private IEnumerable<Vector3Int> FindUniqueCellPosition(IEnumerable<Vector3Int> newCellsPosition) {
        _newPositionCell = CalculatePositionCells(Position, newCellsPosition);
        var result = _newPositionCell.Where(cell => !_currentPositionCell.Contains(cell)).ToList();
        return result;
    }

    private void CalculateCurrentPositionCells() {
        _currentPositionCell = CalculatePositionCells(Position, Cells);
    }
}