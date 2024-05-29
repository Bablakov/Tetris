public class GameStateMachine : FiniteStateMachine {
    public override void AddState(State state) {
        if (!States.ContainsKey(typeof(State))) {
            States.Add(state.GetType(), state);
        }
    }

    public override void SetState<T>() {
        var type = typeof(T);

        if (CurrentState != null && CurrentState.GetType() == type) {
            return;
        }

        if (States.TryGetValue(type, out var newState)) {
            CurrentState?.Exit();
            CurrentState = newState;
            CurrentState.Enter();
        }
    }

    public override void Update() {
        CurrentState?.Update();
    }
}