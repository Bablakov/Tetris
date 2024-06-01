using System;
using UnityEngine;

public class FieldSpawner : MonoBehaviour, IService, IDisposable {
    private int _hieght => _fieldConfig.Hieght;
    private int _width => _fieldConfig.Width;
    private Cell _cellArea => _fieldConfig.CellArea;
    private Transform _cellBoarder => _fieldConfig.CellBoarder;
    
    private FieldConfig _fieldConfig;
    private Cell[][] _field;

    public Field Spawn(FieldConfig fieldConfig) {
        AssignValues(fieldConfig);
        CreateCollectionCells();
        CreateCells();
        return new RectangularField(_field);
    }

    private void AssignValues(FieldConfig fieldConfig) {
        _fieldConfig = fieldConfig;
    }

    private void CreateCollectionCells() {
        _field = new Cell[_hieght][];
        for (int i = 0; i < _hieght; i++) {
            _field[i] = new Cell[_width];
        }
    }

    private void CreateCells() {
        for (int y = 0; y <= _hieght + 1; y++) {
            for (int x = 0; x <= _width + 1; x++) {
                if (x == 0 || y ==0 || x == _width + 1 || y == _hieght + 1) {
                    Instantiate(_cellBoarder, new Vector3Int(x, y, 0), Quaternion.identity, transform);
                } else {
                    SpawnAndSaveCell(y, x);
                    InitializeCell(y, x);
                }
            }
        }
    }

    private void SpawnAndSaveCell(int y, int x) {
        _field[y-1][x-1] = Instantiate(_cellArea, new Vector3Int(x, y, 0), Quaternion.identity, transform);
    }

    private void InitializeCell(int y, int x) {
        _field[y-1][x-1].Initialize();
    }

    public void Dispose() {
    }
}