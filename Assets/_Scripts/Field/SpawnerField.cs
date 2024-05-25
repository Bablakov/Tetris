using System;
using UnityEngine;

public class SpawnerField : MonoBehaviour{
    private int _hieght;
    private int _width;
    private Cell _cell;
    private Cell[][] _fieldGame;

    public Cell[][] Spawn(FieldConfigSO spawnConfig) {
        _hieght = spawnConfig.Hieght;
        _width = spawnConfig.Wieght;
        _cell = spawnConfig.Cell;

        _fieldGame = new Cell[_hieght][];

        for (int y = 0; y < _hieght; y++) {
            
            _fieldGame[y] = new Cell[_width];

            for (int x = 0; x < _width; x++) {
                SpawnAndSaveCell(y, x);
                InitializeCell(y, x);
            }
        }

        return _fieldGame;
    }

    private void SpawnAndSaveCell(int y, int x) {
        _fieldGame[y][x] = Instantiate(_cell, new Vector3Int(x, y, 0), Quaternion.identity, transform);
    }

    private void InitializeCell(int y, int x) {
        _fieldGame[y][x].Initialize(new Vector3Int(x, y));
    }
}