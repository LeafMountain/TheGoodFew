using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalStateHub : StateMachineState {
    private GlobalStateMachine globalStateMachine;

    public GlobalStateHub (GlobalStateMachine globalStateMachine) {
        this.globalStateMachine = globalStateMachine;
    }

    public override void EnterState () {
        //If the right scene is not loaded, load it
        if (SceneManager.GetActiveScene().name != globalStateMachine.villageHub) {
            globalStateMachine.ChangeScene(globalStateMachine.villageHub);
        }
    }


    public override void Update () {
        //When player press the Escape button, go to pause state
        if (Input.GetKeyDown(KeyCode.Escape)) {
            globalStateMachine.ChangeState(new GlobalStatePause(globalStateMachine));
        }
    }
}
