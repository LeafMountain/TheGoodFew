using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnStateMachine : StateMachine {

    public TurnManager UnitManager { get; set; }

    public void ChangeState(StateMachineState newState) {
        if(currentState != null){
            currentState.ExitState();
        }
        currentState = newState; 
        currentState.EnterState();
    }

    private void Start() {
        ChangeState(new TurnStatePrepare(this)); 
    }

    private void Update() {
        currentState.Update(); 
    }
}
