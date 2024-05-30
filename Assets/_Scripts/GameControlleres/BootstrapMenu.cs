using UnityEngine;

public class BootstrapMenu : MonoBehaviour {
    [SerializeField] UIControllerMenu UIControllerMenu;

    private void Awake() {
        UIControllerMenu.Initialize();
    }
        
}