using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonStartGame : BaseButton {
    public override void Initialize() {
        base.Initialize();
        AddMethodInEventClick(LoadGameScene);
        AddEventOnButton();
    }

    private void LoadGameScene() {
        SceneManager.LoadScene("Game");
    }
}