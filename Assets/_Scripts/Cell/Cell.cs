using UnityEngine;
using TMPro;

public class Cell : MonoBehaviour {
    [SerializeField] private VisualElement visualCell;
    [SerializeField] private bool fill;
    [SerializeField] private TextMeshProUGUI text;

    private Vector3Int _position;

    public void Initialize(Vector3Int position) {
        _position = position;
        visualCell.Initialize();
    }

    public bool IsVisible() {
        return fill;
    }

    public void Show(/*Material material*/) {
        visualCell.Enable(/*material*/);
        fill = true;
    }

    public void Hide() {
        visualCell.Disable();
        fill = false;
    }
}