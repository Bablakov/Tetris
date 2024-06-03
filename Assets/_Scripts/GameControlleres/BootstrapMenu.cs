using UnityEngine;

public class BootstrapMenu : MonoBehaviour {
    [SerializeField] private UIControllerMenu UIControllerMenu;

    private void Awake() {
        UIControllerMenu.Initialize();
    }
        
}