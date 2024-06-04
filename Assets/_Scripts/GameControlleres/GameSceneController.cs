using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameSceneController {
    private const string NAME_SCENE_MENU = "Menu";
    private const string NAME_SCENE_GAME = "Game";


    public static void GoGame() {
        SceneManager.LoadScene(NAME_SCENE_GAME);
    }

    public static void GoMenu() {
        SceneManager.LoadScene(NAME_SCENE_MENU);
    }

    public static void RestartScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public static void ExitGame() {
        Application.Quit();
    }
}