using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatStateTurn : StateMachineState {

    private CombatStateMachine combatStateMachine;
    private float nextStateTimer;

    public CombatStateTurn (CombatStateMachine combatStateMachine) {
        this.combatStateMachine = combatStateMachine;
        //Add 1 to turn
        combatStateMachine.CurrentTurn++;

        //Show announcement
        Announcement anno = new Announcement("Fight!");
        nextStateTimer = anno.lifetime;
    }

    public override void Update () {
        //Go to next state when announcement is done
        nextStateTimer -= Time.deltaTime;

        if (nextStateTimer <= 0) {
            combatStateMachine.NextState();
        }

    }
}