using Unity.VisualScripting;
using UnityEngine;

public class PlayingField : MonoBehaviour {
    [SerializeField] private Cell cell;
    [SerializeField, Range(10, 100, order = 1)] private int hieght;
    [SerializeField, Range(10, 100, order = 1)] private int wieght;

    private Cell[][] cells;

    private void Start() {
        SpawnField();
    }

    private void SpawnField() {
        cells = new Cell[hieght][];
        for (int y = 0; y < hieght; y++) {
            cells[y] = new Cell[wieght];
            for (int x = 0; x < wieght; x++) {
                SpawnCellAndSave(y, x);
            }
        }
    }

    private void SpawnCellAndSave(int y, int x) {
        cells[y][x] = Instantiate(cell, new Vector3(x, y, 0), Quaternion.identity);
        cells[y][x].Initialize(y, x);
    }

    private void Update() {
    }
}