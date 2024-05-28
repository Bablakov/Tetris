using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FigureConfig", menuName = "Tetris/FigureConfig")]
public class FigureConfig : ScriptableObject {
    [SerializeField] private List<FigureShape> rotateFigure;
    [SerializeField] private Material materialCell;
    [SerializeField] private Cell cell;

    public IReadOnlyList<FigureShape> RotateFigure => rotateFigure;
    public Material MaterialCell => materialCell;
    public Cell Cell => cell;
}