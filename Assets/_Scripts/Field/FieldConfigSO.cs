using System;
using UnityEngine;

public class FieldConfigSO : ScriptableObject {
    [SerializeField, Range(10, 100)] private readonly int hieght = 20;
    [SerializeField, Range(5, 50)] private readonly int wieght = 10;
    [SerializeField] private readonly Cell cell;

    public int Hieght => hieght;
    public int Wieght => wieght;
    public Cell Cell => cell;
    public Vector3Int PositionSpawn => new Vector3Int(wieght/2, hieght - 2);
}