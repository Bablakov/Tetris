using UnityEngine;

public class CameraController : MonoBehaviour {
    private Camera _camera;

    public void Initialize(float hieght, float width) {
        _camera = GetComponent<Camera>();
        SetUpCamera(hieght, width);
    }


    private void SetUpCamera(float hieght, float width) {
        var size = hieght / 2f + 5;
        var y = hieght / 2f - 3.5f;
        var xWidth = (width / 2f) + 0.5f;
        var x = xWidth;
        Debug.Log(x);
        _camera.transform.position = new Vector3(x, y, -10);
        _camera.orthographicSize = hieght / 2f + 5;
    }
}