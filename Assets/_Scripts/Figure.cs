using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Figure : MonoBehaviour {
    [SerializeField] public CellFigure[] cells;
    [SerializeField] public Vector3Int position;
    [SerializeField] private float speed;
    [SerializeField] public Vector3Int[] positionCells;
    
    private float _time = 0.1f;
    private float _standartTime = 1f;
    private Vector3Int _newPosition;
    private Vector3Int _vectorDown = new Vector3Int(0, -1, 0);

    private PlayingField playingField => PlayingField.instance;

    private void Start() {
        if (playingField.ICanMoveHere(ConcatValue(position))) {
            playingField.ShowFigure(ConcatValue(position));
            _time = _standartTime;
        }
    }

    private void Update() {
        if (_time < 0) {
            _newPosition = new Vector3Int(0, 0, 0);
            if (Input.GetKey(KeyCode.A)) {
                _newPosition += new Vector3Int(-1, 0, 0);
            }
            
            if (Input.GetKey(KeyCode.D)) {
                _newPosition += new Vector3Int(1, 0, 0);
            }

            /*if (Input.GetKey(KeyCode.Q)) {
                transform.localEulerAngles += new Vector3(0, 0, 90);
                time = standartTime;
            }
            
            if (Input.GetKey(KeyCode.E)) {
                transform.localEulerAngles += new Vector3(0, 0, -90);
                time = standartTime;
            }*/
            _newPosition += _vectorDown;


            if (playingField.ICanMoveHere(FindUnique(position, position + _newPosition))) {
                playingField.ShowFigure(ConcatValue(position + _newPosition), ConcatValue(position));
                position += _newPosition;
                _time = _standartTime;
            } 
            
            else if (playingField.ICanMoveHere(FindUnique(position, position + _vectorDown))) {
                playingField.ShowFigure(ConcatValue(position + _vectorDown), ConcatValue(position));
                position += _vectorDown;
                _time = _standartTime;
            }
        }
        _time -= Time.deltaTime;
    }

    private IEnumerable<Vector3Int> ConcatValue(Vector3Int value) {
        var result = positionCells.Select(cell => cell += value).ToList();
        return result;
    }

    private IEnumerable<Vector3Int> FindUnique(Vector3Int oldPosition, Vector3Int newPosition) {
        var collection1 = ConcatValue(oldPosition);
        var collection2 = ConcatValue(newPosition);
        var result = collection2.Where(cell => !collection1.Contains(cell)).ToList();
        return result;
    }
}