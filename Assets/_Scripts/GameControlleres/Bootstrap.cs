using UnityEngine;

public class Bootstrap : MonoBehaviour {
    [SerializeField] private PlayingField playingField;
    [SerializeField] private InputGame _inputGame;

    private void Awake() {
        playingField.Initialize(_inputGame);
    }
}