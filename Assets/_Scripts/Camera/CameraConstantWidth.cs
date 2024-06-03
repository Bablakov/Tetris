using System.Drawing;
using UnityEngine;

public class CameraConstantWidth : MonoBehaviour {
    [SerializeField, Range(0f, 1f)] private float widthOrHeight = 0;
    [SerializeField] public Vector2 DefaultResolution = new Vector2(720, 1280);
    
    private Camera _camera;
    private float _initialSize;
    private float _targetAspect;
    private Vector2 _currentSize;

    public void Initialize() {
        GetComponent();
        InitialValue();
    }

    private void Update() {
        if (IsChangedScreenSize()) {
            RecalculateCameraSize();
            AssignNewValueVariable();
        }
    }

    private void GetComponent() {
        _camera = GetComponent<Camera>();
    }

    private void InitialValue() {
        _initialSize = _camera.orthographicSize;
        _targetAspect = DefaultResolution.x / DefaultResolution.y;
    }

    private bool IsChangedScreenSize() {
        return _currentSize.x != Screen.width || _currentSize.y != Screen.height;
    }

    private void RecalculateCameraSize() {
        float constantWidthSize = _initialSize * (_targetAspect / _camera.aspect);
        _camera.orthographicSize = Mathf.Lerp(constantWidthSize, _initialSize, widthOrHeight);
    }

    private void AssignNewValueVariable() {
        _currentSize = new Vector2(Screen.width, Screen.height);
    }
}