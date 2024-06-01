using System;
using UnityEngine;

public class InputKeyboard : InputGame {
    public override event Action InputedSwapFigure;
    public override event Action InputedRotate;
    public override event Action InputedHardDrope;
    public override event Action<Vector2> InputedMove;

    private Vector2 moveVector;

    public override void Initialize() {
        base.Initialize();
        InputPlayerSystem.Player.Move.started += OnInputMoveStarted;
        //InputPlayerSystem.Player.Move.performed += OnInputMovePerformed;
        InputPlayerSystem.Player.Move.canceled += OnInputMoveCanceled;
    }

    private void Update() {
        ProcessInputData();
    }

    private void ProcessInputData() {
        if(moveVector.magnitude > 0) {
            InputedMove?.Invoke(moveVector);
        }
        if (Input.GetKeyDown(KeyCode.Space)) {
            InputedHardDrope?.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.LeftControl)) {
            InputedSwapFigure?.Invoke();
        }
    }

    private void OnInputMoveStarted(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        moveVector = obj.ReadValue<Vector2>();
    }

    private void OnInputMovePerformed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        moveVector = obj.ReadValue<Vector2>();
    }

    private void OnInputMoveCanceled(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        moveVector = obj.ReadValue<Vector2>();
    }
}