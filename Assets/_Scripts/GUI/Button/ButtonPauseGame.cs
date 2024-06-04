public class ButtonPauseGame : StandartButton {
    public override void Initialize(EventBus eventBus) {
        base.Initialize(eventBus);

        AddMethodInEventClick(PauseGame);
        AddEventOnButton();
    }

    private void PauseGame() {
        EventBus.Invoke(new PausedGameSignal());
    }
}