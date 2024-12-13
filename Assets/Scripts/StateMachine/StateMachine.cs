using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine<EState> : MonoBehaviour where EState : Enum
{
    private Dictionary<EState, BaseState<EState>> states = new Dictionary<EState, BaseState<EState>>();
    private BaseState<EState> currentState;

    public void RegisterState(EState key, BaseState<EState> state)
    {
        if (!states.ContainsKey(key))
            states.Add(key, state);
    }

    public void SetInitialState(EState initialStateKey)
    {
        if (!states.ContainsKey(initialStateKey))
        {
            Debug.LogError($"StateMachine: State '{initialStateKey}' not registered.");
            return;
        }

        currentState = states[initialStateKey];
        currentState.EnterState();
    }

    void Update()
    {
        if (currentState != null)
        {
            currentState.UpdateState();
            EState nextState = GetNextState();

            if (!EqualityComparer<EState>.Default.Equals(nextState, currentState.StateKey))
            {
                TransitionToState(nextState);
            }
        }
    }

    protected abstract EState GetNextState();

    private void TransitionToState(EState newStateKey)
    {
        if (!states.ContainsKey(newStateKey))
        {
            Debug.LogError($"StateMachine: State '{newStateKey}' not registered.");
            return;
        }

        currentState.ExitState();
        currentState = states[newStateKey];
        currentState.EnterState();
    }

    // Delegate Unity events
    void OnTriggerEnter(Collider other) => currentState?.OnTriggerEnter(other);
    void OnTriggerStay(Collider other) => currentState?.OnTriggerStay(other);
    void OnTriggerExit(Collider other) => currentState?.OnTriggerExit(other);
}
