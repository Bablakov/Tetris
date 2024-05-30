using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonRestartGame : MonoBehaviour {
    private TextMeshProUGUI _text;
    private Button _button;
    private Image _image;
    private UnityAction _buttonClickRestartGame;

    public void Initialize() {
        GetComponents();
        CreateButton();
    }

    public void Show() {
        _image.enabled = true;
        _text.enabled = true;
    }

    public void Hide() {
        _image.enabled = false;
        _text.enabled = false;
    }

    private void GetComponents() {
        _text = GetComponentInChildren<TextMeshProUGUI>();
        _button = GetComponent<Button>();
        _image = GetComponent<Image>();
    }

    private void CreateButton() {
        _buttonClickRestartGame += RestartGame;
        _button.onClick.AddListener(_buttonClickRestartGame);
    }

    private void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}