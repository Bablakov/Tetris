using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Figure : MonoBehaviour {
    [SerializeField] private Vector3Int position;
    [SerializeField] private float speed;
    [SerializeField] private List<FigureData> rotationPositions;
    [SerializeField] private int currenPositionRotation = 0;

    private int NewPositionRotation {
        get { 
            return _newPositionRotation; 
        }
        
        set {
            if (value >= rotationPositions.Count) {
                _newPositionRotation = 0;
            }
            else if (value < 0) {
                _newPositionRotation = rotationPositions.Count - 1;
            } 
            else {
                _newPositionRotation = value;
            }
            
        }
    }
    
    private float _time = 0.1f;
    private float _standartTime = 1f;
    private Vector3Int _newPosition;
    private Vector3Int _vectorDown = new Vector3Int(0, -1, 0);
    private int _newPositionRotation = 0;

    private PlayingField playingField => PlayingField.instance;

    private void Start() {
        if (playingField.ICanMoveHere(ConcatValue(position, rotationPositions[NewPositionRotation].cells))) {
            playingField.ShowFigure(ConcatValue(position, rotationPositions[NewPositionRotation].cells));
            _time = _standartTime;
        }
    }

    private void Update() {
        if (_time < 0) {
            _newPosition = new Vector3Int(0, 0, 0);
            _newPositionRotation = currenPositionRotation;

            if (Input.GetKey(KeyCode.A)) {
                _newPosition += new Vector3Int(-1, 0, 0);
            }
            
            if (Input.GetKey(KeyCode.D)) {
                _newPosition += new Vector3Int(1, 0, 0);
            }

            if (Input.GetKey(KeyCode.Q)) {
                NewPositionRotation--;
            }

            if (Input.GetKey(KeyCode.E)) {
                NewPositionRotation++;
            }

            
            
            
            // Вращение фигуры
            if (playingField.ICanMoveHere(FindUnique(rotationPositions[currenPositionRotation].cells,
                    rotationPositions[NewPositionRotation].cells))) {

                playingField.ShowFigure(ConcatValue(position, rotationPositions[NewPositionRotation].cells),
                    ConcatValue(position, rotationPositions[currenPositionRotation].cells));

                currenPositionRotation = NewPositionRotation % rotationPositions.Count;
            } 
            else {
                NewPositionRotation = currenPositionRotation;
            }






            _newPosition += _vectorDown;

            // Опускание фигуры и изменения положения вправо-влево
            if (playingField.ICanMoveHere(FindUnique(position, position + _newPosition))) {

                playingField.ShowFigure(ConcatValue(position + _newPosition, rotationPositions[currenPositionRotation].cells),
                    ConcatValue(position, rotationPositions[currenPositionRotation].cells));

                position += _newPosition;
            } else if (playingField.ICanMoveHere(FindUnique(position, position + _vectorDown))) {

                playingField.ShowFigure(ConcatValue(position + _vectorDown, rotationPositions[currenPositionRotation].cells),
                    ConcatValue(position, rotationPositions[currenPositionRotation].cells));

                position += _vectorDown;
            }
            else {
                Debug.Log("Destroy");
                Destroy(gameObject);
            }

            _time = _standartTime;
        }
        _time -= Time.deltaTime;
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