using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FigureConfig", menuName = "Tetris/FigureConfig")]
public class FigureConfig : ScriptableObject {
    [SerializeField] private List<FigureShape> rotateFigure;
    [SerializeField] private Color color;
    [SerializeField] private Sprite spriteFigure;
    [SerializeField] private Cell cell;

    public IReadOnlyList<FigureShape> RotateFigure => rotateFigure;
    public Color ColorCell => color;
    public Sprite SpriteFigure => spriteFigure;
    public Cell Cell => cell;
}