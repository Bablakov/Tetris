using UnityEngine;

public class GhostCell : MonoBehaviour {
    public void Enable() {
        gameObject.SetActive(true);
    }

    public void Disable() {
        gameObject.SetActive(false);
    }
}