using UnityEngine;

public class Cell : MonoBehaviour {
    [SerializeField] private GameObject fullCell;
    [SerializeField] private bool fill;

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