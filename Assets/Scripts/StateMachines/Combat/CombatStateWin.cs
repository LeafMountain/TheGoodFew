using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatStateWin : StateMachineState {

    private CombatStateMachine combatStateMachine;
    private float nextStateTimer;
    private BattleManager battleManager;

    public CombatStateWin (CombatStateMachine combatStateMachine) {
        this.combatStateMachine = combatStateMachine;
        battleManager = BattleManager.GetInstance();
        nextStateTimer = new Announcement("You Win!").lifetime;

        //Go back to village
        battleManager.GlobalStateMachine.ChangeState(new GlobalStateHub(battleManager.GlobalStateMachine));

    }

    public override void Update () {
        nextStateTimer -= Time.deltaTime;

        if (nextStateTimer < 0) {
            battleManager.GlobalStateMachine.ChangeState(new GlobalStateHub(battleManager.GlobalStateMachine));
            Debug.Log(nextStateTimer);
        }
    }
}