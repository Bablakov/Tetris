using UnityEngine;

public class FilledCell : MonoBehaviour {
    private MeshRenderer _meshRenderer;

    public void Initialize() {
        GetComponent();
    }

    private void GetComponent() {
        _meshRenderer = GetComponentInChildren<MeshRenderer>();
    }

    public void Enable(Material material) {
        _meshRenderer.material = material;
        gameObject.SetActive(true);
    }

    public void Disable() {
        gameObject.SetActive(false);
    }
}