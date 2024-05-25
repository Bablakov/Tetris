using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FigureInfo", menuName = "Tetris/FigureInfo")]
public class FigureConfig : ScriptableObject {
    [SerializeField] private List<FigureData> rotateFigure;
    [SerializeField] private Material materialCell;
    [SerializeField] private Cell cell;

    public IReadOnlyList<FigureData> RotateFigure => rotateFigure;
    public Material MaterialCell => materialCell;
    public Cell Cell => cell;
}