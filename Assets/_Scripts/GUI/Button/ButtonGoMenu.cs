using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonGoMenu : BaseButton {
    private TextMeshProUGUI _text;
    private Image _image;

    public override void Initialize(EventBus eventBus) {
        base.Initialize(eventBus);        
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
        _image = GetComponent<Image>();
    }

    private void CreateButton() {
        AddMethodInEventClick(GoMenu);
        AddEventOnButton();
    }

    private void GoMenu() {
        SceneManager.LoadScene("Menu");
    }
}