﻿using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 

public class TurnStateMachine:MonoBehaviour {

    private ITurnState currentState;

    public TurnManager TurnManager { get; set; }

    public void ChangeState(ITurnState newState) {
        if(currentState != null){
            currentState.ExitState();
        }
        currentState = newState; 
        currentState.EnterState();
        // Debug.Log(currentState);
    }

    private void Start() {
        ChangeState(new TurnStatePrepare(this)); 
    }

    private void Update() {
        currentState.Update();
    }
}