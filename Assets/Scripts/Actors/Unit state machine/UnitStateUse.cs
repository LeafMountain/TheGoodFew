using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStateUse : StateMachineState {

    private UnitStateMachine stateMachine;

    public UnitStateUse (UnitStateMachine stateMachine) {
        this.stateMachine = stateMachine;
    }

    public override void ExitState () {
        stateMachine.csm.battleCont.board.interaction.DeMarkTiles ();
    }
}