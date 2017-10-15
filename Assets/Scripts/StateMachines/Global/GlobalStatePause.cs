using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalStatePause : StateMachineState {
    public GlobalStateMachine globalStateMachine;

    public GlobalStatePause (GlobalStateMachine globalStateMachine) {
        this.globalStateMachine = globalStateMachine;
    }

    public override void EnterState () {
        //Stop time
        Time.timeScale = 0;

        //Show pause menu
        globalStateMachine.pauseMenu.SetActive (true);

        InputController.GetInstance().BackPressed += UnPauseGame;
    }

    public override void ExitState () {
        //Start time
        Time.timeScale = 1;

        //Hide pause menu
        globalStateMachine.pauseMenu.SetActive (false);
    }

    private void UnPauseGame () {
        //Exit pause state on Esc input
        globalStateMachine.ChangeState (new GlobalStatePlaying (globalStateMachine));

    }
}