using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStateMove_Random : StateMachineState {

    private Health target;
    public UnitStateMachine stateMachine { get; private set; }

    public UnitStateMove_Random (UnitStateMachine stateMachine) {
        this.stateMachine = stateMachine;

    }

    public override void EnterState () {
        target = FindTarget ().GetComponent<Health> ();
        stateMachine.unit.GetComponent<GridMover> ().Move (FindTile ().WorldPosition);
        stateMachine.FocusCamera ();
    }

    //Find closest target
    private TurnOrderObject FindTarget () {
        return stateMachine.csm.battleCont.aiHelper.FindClosestTarget (stateMachine.unit.GetComponent<TurnOrderObject> (), stateMachine.csm.battleCont.turnManager.turnOrder);
    }

    //Find closest tile to target
    private Tile FindTile () {
        return stateMachine.csm.battleCont.aiHelper.FindTileClosestToTarget (target.GetComponent<TurnOrderObject> (), stateMachine.csm.battleCont.board.interaction.FindWalkableTiles (stateMachine.unit.GetComponent<GridOccupant> ().CurrentTile, stateMachine.unit.GetComponent<ObjectInformation> ().UnitData.Movement));
    }

    public override void Update () {
        if (stateMachine.unit.GetComponent<GridMover> ().AtDestination) {
            stateMachine.ChangeState (new UnitStateAttack_Random (stateMachine, target));
        }
    }
}