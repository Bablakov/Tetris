using System;
using UnityEngine;

public class VisualElement : MonoBehaviour {
    private MeshRenderer _meshRenderer;

    public void Initialize() {
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