using UnityEngine;
using TMPro;

public class Cell : MonoBehaviour {
    [SerializeField] private GameObject fullCell;
    [SerializeField] private bool fill;
    [SerializeField] private TextMeshProUGUI text;

    public void Initialize(int y, int x) {
        text.text = $"{y}, {x}";
    }

    public bool IsVisible() {
        return fill;
    }

    public void Show() {
        fullCell.SetActive(true);
        fill = true;
    }

    public void Hide() {
        fullCell.SetActive(false);
        fill = false;
    }
}