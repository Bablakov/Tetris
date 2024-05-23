using UnityEngine;

public class Bootstrap : MonoBehaviour {
    [SerializeField] private PlayingField playingField;

    private void Awake() {
        playingField.Initialize();
    }
}