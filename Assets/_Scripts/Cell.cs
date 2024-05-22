using UnityEngine;
using TMPro;

public class Cell : MonoBehaviour {
    [SerializeField] private GameObject fullCell;
    [SerializeField] private GameObject emptyCell;
    [SerializeField] private bool fill;
    [SerializeField] private TextMeshProUGUI textMeshPro;

    public void Initialize(int i, int j) {
        textMeshPro.text = $"{i},{j}";
    }

    public void SetFill(bool fill) {
        this.fill = fill;
    }

    private void Update() {
        if (fill) {
            fullCell.SetActive(true);
            emptyCell.SetActive(false);
        } else {
            fullCell.SetActive(false);
            emptyCell.SetActive(true);
        }
    }
}