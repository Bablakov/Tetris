using System;
using UnityEngine;

[CreateAssetMenu(fileName = "FieldInfo", menuName = "Tetris/FieldInfo")]
public class FieldConfig : ScriptableObject {
    [SerializeField, Range(10, 100)] private int hieght = 20;
    [SerializeField, Range(5, 50)] private int wieght = 10;
    [SerializeField] private Cell cell;

    public int Hieght => hieght;
    public int Wieght => wieght;
    public Cell Cell => cell;
    public Vector3Int PositionSpawn => new Vector3Int(wieght/2, hieght - 2);
}