using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputWithNewSystem : InputGame {
    public override event Action InputedSwapFigure;
    public override event Action InputedRotate;
    public override event Action InputedHardDrope;
    public override event Action<Vector2> InputedMove;

    private float _time = 0;
    private float _standartTime = 0.1f;

    public override void Initialize() {
        base.Initialize();
        InputPlayerSystem.Player.HardDropeFigure.performed += context =>  OnHardDropeFigureInputed();
        InputPlayerSystem.Player.SwapFigure.performed += context => OnSwapFigureInputed();
        InputPlayerSystem.Player.RotateFigure.performed += context => OnRotateFigure();
        //InputPlayerSystem.Player.SlowDropeFigure.performed += context => OnSlowDropeFigureInputed();
        InputPlayerSystem.Player.MoveRight.performed += context => OnMoveRight();
        InputPlayerSystem.Player.MoveLeft.performed += context => OnMoveLeft();
    }

    private void Update() {
        if (_time < 0f) {
            if (InputPlayerSystem.Player.SlowDropeFigure.IsPressed()) {
                InputedMove?.Invoke(new Vector2(0, -1f));
                _time = _standartTime;
            }
        }
        else {
            _time -= Time.deltaTime;
        }
    }

    private void OnHardDropeFigureInputed() {
        InputedHardDrope?.Invoke();
    }

    private void OnSwapFigureInputed() {
        InputedSwapFigure?.Invoke();
    }

    private void OnRotateFigure() {
        InputedRotate?.Invoke();
    }
/*
    private void OnSlowDropeFigureInputed() {
        InputedMove?.Invoke(new Vector2(0, -1f));
    }*/

    private void OnMoveRight() {
        InputedMove?.Invoke(new Vector2(1f, 0));
    }

    private void OnMoveLeft() {
        InputedMove?.Invoke(new Vector2(-1f, 0));
    }
}