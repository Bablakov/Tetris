public abstract class State {
    protected readonly FiniteStateMachine StateMachine;

    public State(FiniteStateMachine stateMachine) {
        StateMachine = stateMachine;
    }

    public virtual void Enter() { }
    public virtual void Exit() { }
    public virtual void EnterState() { }
    public virtual void Update() { }
}