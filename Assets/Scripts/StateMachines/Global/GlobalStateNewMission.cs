using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalStateNewMission : StateMachineState {
    private GlobalStateMachine globalStateMachine;
    private string newMissionScene;

    public GlobalStateNewMission (GlobalStateMachine globalStateMachine, string newMission) {
        this.globalStateMachine = globalStateMachine;
        this.newMissionScene = newMission;
    }

    public override void EnterState () {
        //Go to the scene defined in the MissionData
        globalStateMachine.ChangeScene(newMissionScene);

        //Change to playing state
        globalStateMachine.ChangeState(new GlobalStatePlaying(globalStateMachine));
    }
}
