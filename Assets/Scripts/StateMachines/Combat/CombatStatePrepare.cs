using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatStatePrepare : StateMachineState {

    private CombatStateMachine combatStateMachine;
    private BattleManager battleManager;
    private TurnManager turnManager;
    private float nextStateTimer;

    public CombatStatePrepare (CombatStateMachine combatStateMachine) {
        this.combatStateMachine = combatStateMachine;
        battleManager = BattleManager.GetInstance();
        turnManager = TurnManager.GetInstance();
        
        // turnManager.FindTurnOrderObjects ();
        turnManager.SortUnits();

        if (combatStateMachine.missionData != null)
            nextStateTimer = new Announcement (combatStateMachine.missionData.missionName).lifetime;
    }

    //Finds units and add it to the actionOrder.
    // private void FindUnits () {
    //     foreach (TurnOrderObject unit in GameObject.FindObjectsOfType (typeof (Unit))) {
    //         turnManager.AddUnit (unit);

    //         unit.GetComponent<Unit> ().Move (BattleManager.GetInstance().board.GetTile (battleManager.board.ConvertToBoardPosition (unit.transform.position)));
    //     }

    //     //Sort units to be in the correct order
    //     battleManager.turnManager.SortUnits ();
    // }

    public override void Update () {
        nextStateTimer -= Time.deltaTime;

        if (nextStateTimer <= 0) {
            if (combatStateMachine.missionData != null && combatStateMachine.missionData.startDialogue != null) {
                combatStateMachine.ChangeState (new CombatStateStory (combatStateMachine, combatStateMachine.missionData.startDialogue, 0));
            } else {
                combatStateMachine.ChangeState (new CombatStateTurn (combatStateMachine));
            }

        }
    }
}