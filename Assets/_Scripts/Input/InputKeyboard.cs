using System;
using UnityEngine;

public class InputKeyboard : InputGame {
    public override event Action InputedRotate;
    public override event Action InputedSpace;
    public override event Action InputedRight;
    public override event Action InputedLeft;
    public override event Action InputedDown;

    public override void Initialize() {
    }

    private void Update() {
        ProcessInputData();
    }

    private void ProcessInputData() {
        if (Input.GetKeyDown(KeyCode.A)) {
            InputedLeft?.Invoke();
        } 
        if (Input.GetKeyDown(KeyCode.D)) {
            InputedRight?.Invoke();
        } 
        if (Input.GetKeyDown(KeyCode.W)) {
            InputedRotate?.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.S)) { 
            InputedDown?.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.Space)) {
            InputedSpace?.Invoke();
        }
    }
}