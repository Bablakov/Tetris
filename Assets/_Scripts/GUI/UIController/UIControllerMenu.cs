public class UIControllerMenu : UIController {
    private ButtonStartGame _buttonStartGame;
    //private ButtonExitGame _buttonExitGame;
    //private ButtonWithExternalAction _buttonOpenSettings;

    public override void Initialize() {
        base.Initialize();
        //PanelSettings.Hide();
    }
    
    protected override void GetComponents() {
        base.GetComponents();
        _buttonStartGame = GetComponentInChildren<ButtonStartGame>();
        //_buttonExitGame = GetComponentInChildren<ButtonExitGame>();
        //_buttonOpenSettings = GetComponentInChildren<ButtonWithExternalAction>();
    }

    protected override void InitializeComponents() {
        base.InitializeComponents();
        _buttonStartGame.Initialize(EventBus);
        //_buttonExitGame.Initialize(EventBus);
        //_buttonOpenSettings.Initialize(EventBus, OpenPanelSettings);
    }
/*
    private void OpenPanelSettings() {
        PanelSettings.Show();
    }*/
}