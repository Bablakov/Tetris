using System;
using System.Collections.Generic;
using UnityEngine;

public class FigureController : MonoBehaviour, IService {
    [SerializeField, Range(0.1f, 100f)] private float speed;

    private const float SECOND = 1f;
    private readonly Vector3Int Down = new Vector3Int(0, -1, 0);
    private readonly Vector3Int Right = new Vector3Int(1, 0, 0);
    private readonly Vector3Int Left = new Vector3Int(-1, 0, 0);

    private bool IsDropTime => _currentTime < 0;
    private Vector3Int Position => _figure.Position;
    private IEnumerable<Vector3Int> Cells => _figure.PositionCells.Cells;

    private IEnumerable<Vector3Int> _currentPositionCells;
    private float _currentTime = 0.1f;
    private FieldController _fieldController;
    private InputGame _inputGame;
    private EventBus _eventBus;
    private Figure _figure;

    public void Initialize() {
        GetComponents();
        Subscribe();
    }

    private void Update() {
        MoveDown();
    }

    private void GetComponents() {
        _inputGame = ServiceLocator.Current.Get<InputGame>();
        _eventBus = ServiceLocator.Current.Get<EventBus>();
        _fieldController = ServiceLocator.Current.Get<FieldController>();
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

    private void MoveDown() {
        if (IsDropTime) {
            if (!TryAttemptMove(Down))
                InformPutFigure();
            ResetTime();
        }
        UpdatingTime();
    }

    private void OnInputedRotate() {
        if (IsCanRotate()) {
            Rotate();
        }
    }

    private void OnInputedRight() {
        TryAttemptMove(Right);
    }

    private void OnInputedLeft() {
        TryAttemptMove(Left);
    }

    private void OnInputedDown() {
        TryAttemptMove(Down);
    }

    private void OnInputedSpace() {
        while (TryAttemptMove(Down)) {
        }
        InformPutFigure();
    }

    private void OnSpawnedFigureSignal(SpawnedFigureSignal spawnedFigureSignal) {
        _figure = spawnedFigureSignal.Figure;
        CalculateCurrentPositionCells();
    }

    private bool TryAttemptMove(Vector3Int moveDirection) {
        if (IsCanMove(moveDirection)) {
            Move(moveDirection);
            UpdateDataMove(moveDirection);
            return true;
        } 
        else {
            return false;
        }
    }

    private bool IsCanRotate() {
        return _fieldController.ICanMoveHere(FindUniqueCellPosition(_figure.NextPositionRotateCells.Cells));
    }

    private void Rotate() {
        _fieldController.ShowNewCells(CalculatePositionCells(Position, _figure.NextPositionRotateCells.Cells),
            _currentPositionCells, _figure.MaterialCells);

        _figure.SetNextPositionRotate();
        CalculateCurrentPositionCells();
    }

    private bool IsCanMove(Vector3Int moveDirection) {
        return _fieldController.ICanMoveHere(FindUniqueCellPosition(Position + moveDirection));
    }

    private void Move(Vector3Int moveDirection) {
        _fieldController.ShowNewCells(CalculatePositionCells(Position + moveDirection, Cells),
                _currentPositionCells, _figure.MaterialCells);
    }

    private void UpdateDataMove(Vector3Int moveDirection) {
        _figure.SetPosition(Position + moveDirection);
        CalculateCurrentPositionCells();
    }

    private void InformPutFigure() {
        _eventBus.Invoke(new PutFigureSignal());
    }

    private void UpdatingTime() {
        _currentTime -= Time.deltaTime;
    }

    private void ResetTime() {
        _currentTime =  SECOND / speed;
    }

    private IEnumerable<Vector3Int> CalculatePositionCells(Vector3Int value, IEnumerable<Vector3Int> cells) {
        return Mathematics.CalculatePositionCells(value, cells);
    }

    private IEnumerable<Vector3Int> FindUniqueCellPosition(Vector3Int newPosition) {
        return Mathematics.FindUniqueCellPosition(Position, newPosition, Cells);
    }

    private IEnumerable<Vector3Int> FindUniqueCellPosition(IEnumerable<Vector3Int> newCellsPosition) {
        return Mathematics.FindUniqueCellPosition(Position, Cells, newCellsPosition);
    }

    private void CalculateCurrentPositionCells() {
        _currentPositionCells = Mathematics.CalculatePositionCells(Position, Cells);
    }
}