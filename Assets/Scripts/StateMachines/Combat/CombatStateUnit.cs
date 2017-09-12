using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatStateUnit : StateMachineState {

    private CombatStateMachine combatStateMachine;
    private BattleManager battleManager;

    public CombatStateUnit (CombatStateMachine combatStateMachine) {
        this.combatStateMachine = combatStateMachine;
        battleManager = BattleManager.GetInstance();
        ReduceAbilityCooldowns();
        combatStateMachine.UnitStateMachine = new UnitStateMachine(combatStateMachine, battleManager.turnManager.CurrentUnit.GetComponent<GridMover>());

        combatStateMachine.UpdateUnitState();
    }

    //Reduce ability cooldown
    public void ReduceAbilityCooldowns () {
        for (int i = 0; i < battleManager.turnManager.CurrentUnit.GetComponent<ObjectInformation>().Abilities.Count; i++) {
            battleManager.turnManager.CurrentUnit.GetComponent<ObjectInformation>().Abilities[i].ReduceCooldown();
        }
    }

    public override void Update(){
        combatStateMachine.UnitStateMachine.StateUpdate();
    }
}