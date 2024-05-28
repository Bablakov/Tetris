using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FigureInfo", menuName = "Tetris/FigureConfigs")]
public class FigureConfigs : ScriptableObject {
    [SerializeField] private FigureConfig[] configs;

    public IReadOnlyList<FigureConfig> Configs => configs;
    public int Count => configs.Length;
}