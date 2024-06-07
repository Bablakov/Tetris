using System;
using UnityEngine;

public class InputWithNewSystem : InputGame {
    public override event Action InputedSwapFigure;
    public override event Action InputedRotate;
    public override event Action InputedHardDrope;
    public override event Action<Vector2> InputedMove;

    private readonly Vector2 Down = new Vector2(0, -1f);
    private readonly Vector2 Left = new Vector2(-1, 0);
    private readonly Vector2 Right = new Vector2(1, 0);

    private float _time = 0;
    private float _standartTime = 0.1f;

    private bool isCanGetData => _time < 0f;
    private bool isPressedKeyDown => InputPlayerSystem.Player.SlowDropeFigure.IsPressed();

    public override void Initialize() {
        base.Initialize();
    }

    private void Update() {
        ProcessInput();
    }

    protected override void Subscribe() {
        base.Subscribe();
        InputPlayerSystem.Player.HardDropeFigure.performed += context => OnHardDropeFigureInputed();
        InputPlayerSystem.Player.SwapFigure.performed += context => OnSwapFigureInputed();
        InputPlayerSystem.Player.RotateFigure.performed += context => OnRotateFigure();
        InputPlayerSystem.Player.MoveRight.performed += context => OnMoveRight();
        InputPlayerSystem.Player.MoveLeft.performed += context => OnMoveLeft();
    }

    protected override void Unsubscribe() {
        base.Unsubscribe();
        InputPlayerSystem.Player.HardDropeFigure.performed -= context => OnHardDropeFigureInputed();
        InputPlayerSystem.Player.SwapFigure.performed -= context => OnSwapFigureInputed();
        InputPlayerSystem.Player.RotateFigure.performed -= context => OnRotateFigure();
        InputPlayerSystem.Player.MoveRight.performed -= context => OnMoveRight();
        InputPlayerSystem.Player.MoveLeft.performed -= context => OnMoveLeft();
    }

    private void ProcessInput() {
        if (isCanGetData) {
            if (isPressedKeyDown && !Finished) {
                SendInputData();
                ResetTime();
            }
        } else {
            ReduceTime();
        }
    }

    private void OnHardDropeFigureInputed() {
        if (!Finished)
            InputedHardDrope?.Invoke();
    }

    private void OnSwapFigureInputed() {
        if (!Finished)
            InputedSwapFigure?.Invoke();
    }

    private void OnRotateFigure() {
        if (!Finished)
            InputedRotate?.Invoke();
    }
    private void OnMoveRight() {
        if (!Finished)
            InputedMove?.Invoke(Right);
    }

    private void OnMoveLeft() {
        if (!Finished)
            InputedMove?.Invoke(Left);
    }
    private void SendInputData() {
        if (!Finished)
            InputedMove?.Invoke(Down);
    }

    private void ResetTime() {
        _time = _standartTime;
    }

    private void ReduceTime() {
        _time -= Time.deltaTime;
    }
}