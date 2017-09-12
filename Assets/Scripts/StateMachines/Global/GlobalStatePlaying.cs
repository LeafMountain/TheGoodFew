using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalStatePlaying : StateMachineState {

    public GlobalStateMachine globalStateMachine;

    public GlobalStatePlaying (GlobalStateMachine globalStateMachine) {
        this.globalStateMachine = globalStateMachine;
    }

    public override void EnterState () {
        InputManager.GetInstance().BackPressed += PauseGame;
    }

    private void PauseGame () {
        //Go to pause state
        globalStateMachine.ChangeState (new GlobalStatePause (globalStateMachine));        
    }
}