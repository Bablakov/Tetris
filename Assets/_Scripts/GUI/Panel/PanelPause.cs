public class PanelPause : HidingPanel {
    private const string TEXT_BUTTON_OPEN_SETTINGS = "Settings";

    private ButtonWithExternalAction _buttonWithExternalAction;
    private ButtonResumeGame _buttonResumeGame;
    private ButtonExitGame _buttonExitGame;
    private PanelSettings _panelSettings;

    public override void Initialize(EventBus eventBus) {
        base.Initialize(eventBus);
        Subscribe();
    }

    public void SetValue(PanelSettings panelSettings) {
        _panelSettings = panelSettings;
    }

    protected override void GetComponents() {
        base.GetComponents();
        _buttonResumeGame = GetComponentInChildren<ButtonResumeGame>();
        _buttonWithExternalAction = GetComponentInChildren<ButtonWithExternalAction>();
        _buttonExitGame = GetComponentInChildren<ButtonExitGame>();
    }

    protected override void InitializeComponents() {
        _buttonResumeGame.Initialize(EventBus);
        _buttonWithExternalAction.Initialize(EventBus, ShowSettingsPanel, TEXT_BUTTON_OPEN_SETTINGS);
        _buttonExitGame.Initialize(EventBus);
    }
    private void Subscribe() {
        EventBus.Subscribe<PausedGameSignal>(OnPausedGame);
        EventBus.Subscribe<ResumedGameSignal>(OnStartedGame);
    }

    private void Unsubscribe() {
        EventBus.Unsubscribe<PausedGameSignal>(OnPausedGame);
        EventBus.Unsubscribe<ResumedGameSignal>(OnStartedGame);
    }

    private void OnPausedGame(PausedGameSignal signal) {
        Show();
    }

    private void OnStartedGame(ResumedGameSignal signal) {
        Hide();
    }

    public override void Show() {
        base.Show();
        ShowChildren();
    }

    public override void Hide() {
        base.Hide();
        HideChildren();
    }

    private void ShowSettingsPanel() {
        _panelSettings.Show();
    }

    private void ShowChildren() {
        _buttonWithExternalAction.Show();
        _buttonExitGame.Show();
        _buttonResumeGame.Show();
    }

    private void HideChildren() {
        _buttonWithExternalAction.Hide();
        _buttonExitGame.Hide();
        _buttonResumeGame.Hide();
    }

    public void Dispose() {
        Unsubscribe();
    }
}