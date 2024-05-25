using System;
using UnityEngine;

public class InputKeyboard : InputGame {
    [SerializeField, Range(0.1f, 10f)] private float timeInput = 0.1f;
    public override event Action InputedRotate;
    public override event Action InputedSpace;
    public override event Action InputedRight;
    public override event Action InputedLeft;
    public override event Action InputedDown;

    private bool IsCanGetData => _time <= 0;
    private float _time;

    public override void Initialize() {
        _time = 0;
    }

    private void Update() {
        if (IsCanGetData) {
            ProcessInputData();
        } 
        else {
            UpdatingTime();
        }
    }

    private void ProcessInputData() {
        if (Input.GetKey(KeyCode.A)) {
            InputedLeft?.Invoke();
            ResetTime();
        } 
        if (Input.GetKey(KeyCode.D)) {
            InputedRight?.Invoke();
            ResetTime();
        } 
        if (Input.GetKey(KeyCode.W)) {
            InputedRotate?.Invoke();
            ResetTime();
        }
        if (Input.GetKey(KeyCode.S)) { 
            InputedDown?.Invoke();
            ResetTime();
        }
        if (Input.GetKey(KeyCode.Space)) {
            InputedSpace?.Invoke();
            ResetTime();
        }
    }

    private void UpdatingTime() {
        _time -= Time.deltaTime;
    }

    private void ResetTime() {
        _time = timeInput;
    }

}