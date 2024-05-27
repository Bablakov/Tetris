using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class FigureShape {
    [SerializeField] private Vector3Int[] _сells;

    public IReadOnlyList<Vector3Int> Cells => _сells;
}