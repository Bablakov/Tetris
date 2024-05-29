using System;
using UnityEngine;

public class FieldSpawner : MonoBehaviour, IService, IDisposable {
    private int _hieght => _fieldConfig.Hieght;
    private int _width => _fieldConfig.Width;
    private Cell _cell => _fieldConfig.Cell;
    
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
        for (int y = 0; y < _hieght; y++) {
            for (int x = 0; x < _width; x++) {
                SpawnAndSaveCell(y, x);
                InitializeCell(y, x);
            }
        }
    }

    private void SpawnAndSaveCell(int y, int x) {
        _field[y][x] = Instantiate(_cell, new Vector3Int(x, y, 0), Quaternion.identity, transform);
    }

    private void InitializeCell(int y, int x) {
        _field[y][x].Initialize();
    }

    public void Dispose() {
    }
}