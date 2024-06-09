using UnityEngine;

public class FilledCell : MonoBehaviour {
    private SpriteRenderer _sprite;

    public void Initialize() {
        GetComponent();
    }

    private void GetComponent() {
        _sprite = GetComponentInChildren<SpriteRenderer>();
    }

    public void Enable(Color color) {
        _sprite.color = color;
        gameObject.SetActive(true);
    }

    public void Disable() {
        gameObject.SetActive(false);
    }
}