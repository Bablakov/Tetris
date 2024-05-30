using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonStartGame : MonoBehaviour {
    private Button _button;
    private UnityAction _buttonClickStartGame;

    public void Initialize() {
        _button = GetComponent<Button>();
        _buttonClickStartGame += LoadGameScene;
        _button.onClick.AddListener(_buttonClickStartGame);
    }

    private void LoadGameScene() {
        SceneManager.LoadScene("Game");
    }
}