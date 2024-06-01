using System;
using System.Collections.Generic;
using UnityEngine;

public class FigureController : MonoBehaviour, IService, IDisposable {
    private const float SECOND = 1f;
    private readonly Vector3Int Down = new Vector3Int(0, -1, 0);
    private readonly Vector3Int Right = new Vector3Int(1, 0, 0);
    private readonly Vector3Int Left = new Vector3Int(-1, 0, 0);
    private readonly Vector3Int Zero = new Vector3Int(0, 0, 0);

    private bool IsDropTime => _currentTime < 0;
    private Vector3Int Position => _figure.Position;
    private IEnumerable<Vector3Int> Cells => _figure.PositionCells.Cells;

    private IEnumerable<Vector3Int> _currentPositionCells;
    private float _currentTime = 0.1f;
    private FieldController _fieldController;
    private InputGame _inputGame;
    private EventBus _eventBus;
    private Figure _figureSwap;
    private Figure _figure;
    private float _initialSpeed;
    private float _speed;

    public void Initialize(float speed) {
        AssignValue(speed);
        GetComponents();
        Subscribe();
    }

    private void AssignValue(float speed) {
        _initialSpeed = speed;
        _speed = speed;
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
        _inputGame.InputedMove += OnInputedMove;
        _inputGame.InputedRotate += OnInputedRotate;
        _inputGame.InputedHardDrope += OnInputedHardDrope;
        _inputGame.InputedSwapFigure += OnInputedSwapFigure;
        _eventBus.Subscribe<SpawnedFigureSignal>(OnSpawnedFigureSignal);
        _eventBus.Subscribe<CreatedFigureSwapSignal>(OnCreatedFigureSwap);
        _eventBus.Subscribe<DeletedCountLineSignal>(OnDeletedCountLine);
    }

    private void Unsubscibe() {
        _inputGame.InputedMove -= OnInputedMove;
        _inputGame.InputedRotate -= OnInputedRotate;
        _inputGame.InputedHardDrope -= OnInputedHardDrope;
        _inputGame.InputedSwapFigure -= OnInputedSwapFigure;
        _eventBus.Unsubscribe<SpawnedFigureSignal>(OnSpawnedFigureSignal);
        _eventBus.Unsubscribe<CreatedFigureSwapSignal>(OnCreatedFigureSwap);
        _eventBus.Unsubscribe<DeletedCountLineSignal>(OnDeletedCountLine);
    }

    public void MoveDown() {
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

    private void OnInputedMove(Vector2 vectorMove) {
        TryAttemptMove(new Vector3Int((int)vectorMove.x, (int)vectorMove.y));
    }

    private void OnInputedHardDrope() {
        while (TryAttemptMove(Down)) {
        }
        InformPutFigure();
    }

    private void OnInputedSwapFigure() {
        TryAppearSwapFigure();
    }

    private void OnSpawnedFigureSignal(SpawnedFigureSignal signal) {
        _figure = signal.Figure;
        CalculateCurrentPositionCells();
        if (!TryAppear()) {
            _eventBus.Invoke(new FinishedGameSignal());
        }
    }

    private void OnCreatedFigureSwap(CreatedFigureSwapSignal signal) {
        _figureSwap = signal.FigureSwap;
        _eventBus?.Invoke(new SwapedFigureVisualSignal(_figureSwap));
    }

    private void OnDeletedCountLine(DeletedCountLineSignal signal) {
        _speed = _initialSpeed + signal.Score / 100f;
    }

    private bool TryAppear() {
        if (IsCanAppear()) {
            Move(Zero);
            return true;
        } else {
            return false;
        }
    }

    private void TryAppearSwapFigure() {
        if (IsCanAppear(_figureSwap.PositionCells.Cells)) {
            var figure = _figure;
            _figure = _figureSwap;
            _figure.SetPosition(figure.Position);
            _figureSwap = figure;
            Move(Zero);
            CalculateCurrentPositionCells();
            _eventBus?.Invoke(new SwapedFigureSignal(_figure));
            _eventBus?.Invoke(new SwapedFigureVisualSignal(_figureSwap));
        }
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

    private bool IsCanAppear() {
        return _fieldController.ICanMoveHere(CalculatePositionCells(Position, Cells));
    }

    private bool IsCanAppear(IEnumerable<Vector3Int> newCell) {
        return _fieldController.ICanMoveHere(FindUniqueCellPosition(newCell));
    }

    private bool IsCanMove(Vector3Int moveDirection) {
        return _fieldController.ICanMoveHere(FindUniqueCellPosition(Position + moveDirection));
    }

    private void Move(Vector3Int moveDirection) {
        _fieldController.ShowNewCells(CalculatePositionCells(Position + moveDirection, Cells),
                _currentPositionCells, _figure.MaterialCells);
    }

    private void UpdateDataMove(Vector3Int moveDirection) {
        if (Position != Position + moveDirection) {
            _figure.SetPosition(Position + moveDirection);
            CalculateCurrentPositionCells();
        }
    }

    private void InformPutFigure() {
        _eventBus.Invoke(new PutFigureSignal());
    }

    private void UpdatingTime() {
        _currentTime -= Time.deltaTime;
    }

    private void ResetTime() {
        _currentTime =  SECOND / _speed;
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

    public void Dispose() {
        Unsubscibe();
        Destroy(gameObject);
    }
}