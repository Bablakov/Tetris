using UnityEngine;

public class UIControllerMenu : MonoBehaviour {
    private ButtonStartGame _buttonStartGame;

    public void Initialize() {
        GetComponent();
        InitializeComponent();
    }
    
    private void GetComponent(){
        _buttonStartGame = GetComponentInChildren<ButtonStartGame>();
    }

    private void InitializeComponent() {
        _buttonStartGame.Initialize();
    }
}