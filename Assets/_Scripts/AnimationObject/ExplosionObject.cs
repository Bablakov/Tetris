using UnityEngine;

public class ExplosionObject : MonoBehaviour {
    [SerializeField, Range(0.1f, 10f)] private float lifeTime = 1f;
    private Renderer[] _renderers;

    public void Initialize(Color color) {
        _renderers = GetComponentsInChildren<Renderer>();
        foreach (var r in _renderers) {
            r.material.color = color;
        }
        Destroy(gameObject, lifeTime);
    }
}