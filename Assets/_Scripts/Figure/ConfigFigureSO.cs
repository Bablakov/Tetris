using System;
using System.Collections.Generic;
using UnityEngine;

public class ConfigFigureSO : ScriptableObject {
    [SerializeField] private readonly List<FigureData> rotateFigure;
    [SerializeField] private readonly Material materialCell;
    [SerializeField] private readonly Cell cell;

    public List<FigureData> RotateFigure => rotateFigure;
    public Material MaterialCell => materialCell;
    public Cell Cell => cell;
}