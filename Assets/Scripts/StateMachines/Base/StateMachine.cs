using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine : MonoBehaviour {
    protected StateMachineState currentState;


    public void ChangeState (StateMachineState newState) {
        if (currentState != null) {
            currentState.ExitState ();
        }
        currentState = newState;
        currentState.EnterState ();
        OnChangeState ();
    }

    public virtual void OnChangeState () {

    }

    private void Update () {
        currentState.Update ();
        OnUpdate ();
    }

    public virtual void OnUpdate () {

    }
}