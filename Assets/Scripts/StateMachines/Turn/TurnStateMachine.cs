using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnStateMachine : StateMachine {


<<<<<<< HEAD
    public UnitManager UnitManager { get; set; }

    public void ChangeState(ITurnState newState) {
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
=======
>>>>>>> parent of c11bb99... TurnStateMachine update and Unit Manager
}
