using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStateIdle : StateMachineState {

    protected UnitStateMachine stateMachine;

    public UnitStateIdle (UnitStateMachine stateMachine) {
        this.stateMachine = stateMachine;
    }

    public override void EnterState () {
        //If unit is hostile , go to ai state
        if (stateMachine.unitAI == null) {
            stateMachine.ChangeState (new UnitStateIdle_Random (stateMachine));
        }
        //If unit has actions left, wait for input, else go to next state
        else {
            if (stateMachine.moved && stateMachine.usedAction)
                stateMachine.EndTurn ();
            else {
                if (!stateMachine.moved)
                    stateMachine.ChangeState (new UnitStateMove (stateMachine));
            }
        }
        stateMachine.FocusCamera ();
    }
}