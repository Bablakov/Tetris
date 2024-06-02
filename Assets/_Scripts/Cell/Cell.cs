using UnityEngine;

[SelectionBase]
public class Cell : MonoBehaviour {
    [SerializeField] private FilledCell filledCell;
    [SerializeField] private GhostCell ghostCell;
    [SerializeField] private ExplosionObject explosionObject;
     
    public bool IsVisible { get; private set; }
    public Material Material { get; private set; }

    public void Initialize() {
        filledCell.Initialize();
    }

    public void Show(Material material) {
        Material = material;
        filledCell.Enable(material);
        IsVisible = true;
    }

    public void Hide(bool delete = false) {
        if (delete) {
            var explosion = Instantiate(explosionObject, transform.position + new Vector3Int(0, 0, -1), transform.rotation);
            explosion.Initialize(Material.color);
        }
        filledCell.Disable();
        IsVisible = false;
    }

    public void ShowGhost() {
        ghostCell.Enable();
    }

    public void HideGhost() {
        ghostCell.Disable();
    }
}