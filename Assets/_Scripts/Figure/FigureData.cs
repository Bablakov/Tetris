using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class FigureData {
    [SerializeField] private readonly List<Vector3Int> _сells;

    public List<Vector3Int> Cells => _сells;
}