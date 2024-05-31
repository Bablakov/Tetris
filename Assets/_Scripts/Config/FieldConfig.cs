using System;
using UnityEngine;

[CreateAssetMenu(fileName = "FieldConfig", menuName = "Tetris/FieldConfig")]
public class FieldConfig : ScriptableObject {
    [SerializeField, Range(10, 50)] private int hieght = 20;
    [SerializeField, Range(5, 25)] private int width = 10;
    [SerializeField] private Transform cellBoarder;
    [SerializeField] private Cell cellArea;

    public int Width => width;
    public int Hieght => hieght;
    public Cell CellArea => cellArea;
    public Transform CellBoarder => cellBoarder;
    public Vector3Int PositionSpawn => new Vector3Int(width/2, hieght - 2);

    private void OnValidate() {
        if (hieght % 2 != 0) {
            hieght = hieght + 1;
            if (hieght % width != 0) {
                width = hieght / 2;
            }
        }
        if (hieght % width != 0) {
            width = hieght / 2;
        }
    }
}