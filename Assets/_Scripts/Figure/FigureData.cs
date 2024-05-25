using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class FigureData {
    [SerializeField] private List<Vector3Int> _сells;

    public IReadOnlyList<Vector3Int> Cells => _сells;
}