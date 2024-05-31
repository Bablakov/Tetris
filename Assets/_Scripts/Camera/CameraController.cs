using UnityEngine;

public class CameraController : MonoBehaviour {
    private Camera _camera;

    public void Initialize(float hieght, float width) {
        _camera = GetComponent<Camera>();
        SetUpCamera(hieght, width);
    }


    private void SetUpCamera(float hieght, float width) {
        _camera.transform.position = new Vector3(width / 2f - 0.5f, hieght / 2f - 0.5f, -10);
        _camera.orthographicSize = hieght / 2f + 3;
    }
}