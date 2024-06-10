using UnityEngine;

public class ExplosionObject : MonoBehaviour {
    [SerializeField, Range(0.1f, 10f)] private float lifeTime = 1f;
    private ParticleSystem _particleSystem;

    public void Initialize(Color color) {
        var _particleSystem = GetComponentInChildren<ParticleSystem>();

        _particleSystem.startColor = color;

        Destroy(gameObject, lifeTime);
    }
}