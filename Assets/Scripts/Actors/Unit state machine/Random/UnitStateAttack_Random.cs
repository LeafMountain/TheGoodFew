using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStateAttack_Random : StateMachineState {
        public UnitStateMachine stateMachine { get; private set; }

    private Health target;

    public UnitStateAttack_Random (UnitStateMachine stateMachine, Health target) {
        this.target = target;
        this.stateMachine = stateMachine;
    }

    public override void EnterState () {
        stateMachine.FocusCamera();

        //If target is next to this unit, attack it
        if (stateMachine.csm.battleCont.board.interaction.GetTilesArea(stateMachine.unit.GetComponent<GridOccupant>().CurrentTile, 1).Contains(target.GetComponent<GridOccupant>().CurrentTile)) {
            AttackTarget();
        }

        stateMachine.EndTurn();
    }

    private void AttackTarget () {
        stateMachine.csm.battleCont.abilitySystem.UseAbility(stateMachine.unit.GetComponent<TurnOrderObject>(), stateMachine.unit.GetComponent<ObjectInformation>().Abilities[0]);
        stateMachine.csm.battleCont.abilitySystem.ExecuteAbility(target);
    }
}
