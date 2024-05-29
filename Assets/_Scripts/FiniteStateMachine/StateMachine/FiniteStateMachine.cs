using System;
using System.Collections.Generic;

public abstract class FiniteStateMachine {
    protected State CurrentState {  get; set; }
    protected Dictionary<Type, State> States = new();

    public abstract void AddState(State state);

    public abstract void SetState<T>() where T : State;

    public abstract void Update();
}