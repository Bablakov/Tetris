using DreamTeamMobile;
using System;

public class GameAnalyticsController: IDisposable {
    private EventBus _eventBus;

    public GameAnalyticsController(EventBus eventBus) {
        _eventBus = eventBus;
        Subscribe();                                                                             
    }

    private void Subscribe() {
        _eventBus.Subscribe<RestartedGameSignal>(OnRestartedGame);
    }

    private void Unsubscribe() {
        _eventBus.Unsubscribe<RestartedGameSignal>(OnRestartedGame);
    }

    private void OnRestartedGame(RestartedGameSignal game) {
        GoogleAnalytics.Instance.TrackEvent("RestartGame");
    }

    public void Dispose() {
        Unsubscribe();
    }
}