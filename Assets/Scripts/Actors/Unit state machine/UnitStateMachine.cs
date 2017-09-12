using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStateMachine {

    public CombatStateMachine csm { get; private set; }
    public StateMachineState currentState { get; private set; }
    public GridMover unit { get; private set; }
    public InputManager inputManager;
    public AI unitAI;
    public bool moved;
    public bool usedAction;

    //Events
    public delegate void Position (Vector3 movePos);
    public event Position MovePicked;

    public UnitStateMachine (CombatStateMachine csm, GridMover unit) {
        this.unit = unit;
        this.csm = csm;
        this.unitAI = unit.ai;
        this.inputManager = InputManager.GetInstance ();

        // inputManager.MarkerExecute += OnMarkerExecute;

        if (unitAI != null) {
            unitAI.EnterAI ();
        }

        ChangeState (new UnitStateIdle (this));
        csm.battleCont.turnManager.UpdateTurnOrder ();

        if (unit.GetComponent<TurnOrderObject> ().allegiance == TurnOrderObject.Allegiance.Friendly) {
            inputManager.NextPressed += EndTurn;
        }
    }

    //Change state
    public void ChangeState (StateMachineState newPhase) {
        if (currentState != null) {
            currentState.ExitState ();
        }

        currentState = newPhase;
        currentState.EnterState ();

        csm.UpdateUnitState ();
    }

    public void EndTurn () {
        currentState.ExitState ();

        if (unitAI != null) {
            unitAI.ExitAI ();
        }

        inputManager.NextPressed -= EndTurn;

        csm.battleCont.abilitySystem.ResetAbility ();
        csm.battleCont.combatStateMachine.NextState ();
    }

    private void OnMovePicked (Vector3 movePos) {
        if (MovePicked != null) {
            MovePicked.Invoke (movePos);
        }
    }

    //Force move camera to unit
    public void FocusCamera () {
        csm.battleCont.cameraControls.Move (unit.Destination);
    }
    public void StateUpdate () {
        currentState.Update ();
    }
}