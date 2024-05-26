using UnityEngine;
using TMPro;

[SelectionBase]
public class Cell : MonoBehaviour {
    [SerializeField] private VisualElement visualCell;
    [SerializeField] private GameObject ghostCell;
    [SerializeField] private bool fill;
    [SerializeField] private TextMeshProUGUI text;
    public Material Material;

    private Vector3Int _position;

    public void Initialize(Vector3Int position) {
        _position = position;
        visualCell.Initialize();
    }

    public bool IsVisible() {
        return fill;
    }

    public void Show(Material material) {
        Material = material;
        visualCell.Enable(material);
        fill = true;
    }

    public void Hide() {
        visualCell.Disable();
        fill = false;
    }

    public void ShowGhost() {
        ghostCell.SetActive(true);
    }

    public void HideGhost() {
        ghostCell.SetActive(false);
    }
}