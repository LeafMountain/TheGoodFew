using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatStateLose : StateMachineState {

    private CombatStateMachine combatStateMachine;
    private float nextStateTimer;
    private GlobalStateMachine globalStateMachine;

    public CombatStateLose (CombatStateMachine combatStateMachine) {
        this.combatStateMachine = combatStateMachine;
        globalStateMachine = GlobalStateMachine.GetInstance();
        
        nextStateTimer = new Announcement ("You Lose!").lifetime;

        //Go back to village
        GlobalStateMachine.GetInstance().ChangeState (new GlobalStateHub (globalStateMachine));
    }

    public override void Update () {
        nextStateTimer -= Time.deltaTime;

        if (nextStateTimer < 0) {
            globalStateMachine.ChangeState (new GlobalStateHub (globalStateMachine));
        }
    }
}