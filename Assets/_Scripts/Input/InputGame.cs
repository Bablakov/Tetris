using System;
using UnityEngine;

public abstract class InputGame : MonoBehaviour {
    public abstract event Action InputedRight;
    public abstract event Action InputedLeft;
    public abstract event Action InputedRotate;
    public abstract event Action InputedSpace;

    public abstract void Initialize();
}