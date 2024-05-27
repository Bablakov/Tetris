using System;
using UnityEngine;

public abstract class InputGame : MonoBehaviour, IService {
    public abstract event Action InputedRotate;
    public abstract event Action InputedRight;
    public abstract event Action InputedSpace;
    public abstract event Action InputedDown;
    public abstract event Action InputedLeft;

    public abstract void Initialize();
}