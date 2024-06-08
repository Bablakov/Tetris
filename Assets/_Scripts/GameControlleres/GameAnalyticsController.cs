using System;

public class GameAnalyticsController: IDisposable {
    private EventBus _eventBus;

    public GameAnalyticsController(EventBus eventBus) {
        _eventBus = eventBus;
        Subscribe();                                                                             
    }

    private void Subscribe() {

    }

    private void Unsubscribe() {

    }

    public void Dispose() {
        Unsubscribe();
    }
}