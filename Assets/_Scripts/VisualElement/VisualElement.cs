using System;
using UnityEngine;

public class VisualElement : MonoBehaviour {
    private MeshRenderer _meshRenderer;

    public void Initialize() {
        _meshRenderer = GetComponentInChildren<MeshRenderer>();
    }

    public void Enable(/*Material material*/) {
        enabled = true;
        //_meshRenderer.material = material;
    }

    public void Disable() {
        enabled = false;
    }
}