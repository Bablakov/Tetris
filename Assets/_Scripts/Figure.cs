using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Figure : MonoBehaviour {
    [SerializeField] private Vector3Int position;
    [SerializeField, Range(0.1f, 100f)] private float timeStandart;
    [SerializeField] private List<FigureData> rotationPositions;
    [SerializeField] private int currenPositionRotation = 0;

    private readonly Vector3Int Down = new Vector3Int(0, -1, 0);
    private readonly Vector3Int Right = new Vector3Int(1, 0, 0);
    private readonly Vector3Int Left = new Vector3Int(-1, 0, 0);
    public event Action Stopped;

    private int NewPositionRotation {
        get { 
            return _newPositionRotation; 
        }
        
        set {
            if (value >= rotationPositions.Count) {
                _newPositionRotation = 0;
            }
            else {
                _newPositionRotation = value;
            }
            
        }
    }
    
    private float _time = 0.1f;
    private Vector3Int _newPosition;
    private int _newPositionRotation = 0;
    private InputGame _inputGame;

    private PlayingField playingField => PlayingField.instance;

    public void Initialize(Vector3Int positionStart, InputGame inputGame) {
        _inputGame = inputGame;
        Subscribe();
        position = positionStart;
    }

    private void Update() {
        if (_time < 0) {

            if (!Move(Down)) {
                Unsubscibe();
                Stopped?.Invoke();
            }
            _time = timeStandart;
        }
        _time -= Time.deltaTime;
    }

    private void Subscribe() {
        _inputGame.InputedLeft += OnInputedLeft;
        _inputGame.InputedRight += OnInputedRight;
        _inputGame.InputedRotate += OnInputedRotate;
    }

    private void Unsubscibe() {
        _inputGame.InputedLeft -= OnInputedLeft;
        _inputGame.InputedRight -= OnInputedRight;
        _inputGame.InputedRotate -= OnInputedRotate;
    }

    private void OnInputedRotate() {
        NewPositionRotation++;
        if (playingField.ICanMoveHere(FindUnique(rotationPositions[currenPositionRotation].cells,
                    rotationPositions[NewPositionRotation].cells))) {

            playingField.ShowFigure(ConcatValue(position, rotationPositions[NewPositionRotation].cells),
                ConcatValue(position, rotationPositions[currenPositionRotation].cells));
            
            currenPositionRotation = NewPositionRotation;
        }
        else {
            NewPositionRotation--;
        }
    }

    private void OnInputedRight() {
        Move(Right);
    }

    private void OnInputedLeft() {
        Move(Left);
    }

    private bool Move(Vector3Int moveDirection) {
        if (playingField.ICanMoveHere(FindUnique(position, position + moveDirection))) {

            playingField.ShowFigure(ConcatValue(position + moveDirection, rotationPositions[currenPositionRotation].cells),
                ConcatValue(position, rotationPositions[currenPositionRotation].cells));

            position += moveDirection;
            return true;
        }
        return false;
    }
    private IEnumerable<Vector3Int> ConcatValue(Vector3Int value, IEnumerable<Vector3Int> cells) {
        var result = cells.Select(cell => cell += value).ToList();
        return result;
    }

    private IEnumerable<Vector3Int> FindUnique(Vector3Int oldPosition, Vector3Int newPosition) {
        var collection1 = ConcatValue(oldPosition, rotationPositions[NewPositionRotation].cells);
        var collection2 = ConcatValue(newPosition, rotationPositions[NewPositionRotation].cells);
        var result = collection2.Where(cell => !collection1.Contains(cell)).ToList();
        return result;
    }

    private IEnumerable<Vector3Int> FindUnique(IEnumerable<Vector3Int> oldCellsPosition, IEnumerable<Vector3Int> newCellsPosition) {
        var collection1 = ConcatValue(position, oldCellsPosition);
        var collection2 = ConcatValue(position, newCellsPosition);
        var result = collection2.Where(cell => !collection1.Contains(cell)).ToList();
        return result;
    }
}