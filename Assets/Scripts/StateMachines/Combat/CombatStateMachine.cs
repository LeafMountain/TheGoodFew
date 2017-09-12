using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatStateMachine : StateMachine {

    public BattleManager battleCont { get; private set; }
    public int CurrentTurn { get; set; }
    public UnitStateMachine UnitStateMachine { get; set; }
    public MissionData missionData;

    public void Start () {
        this.battleCont = GetComponent<BattleManager> ();
        ChangeState (new CombatStatePrepare (this));
    }

    //Change state
    public override void OnChangeState () {
        OnUnitStateUpdated ();
    }

    //Changes states depending on turn and check if a team has won
    public void NextState () {
        if (CurrentTurn == 0) {
            ChangeState (new CombatStateTurn (this));
            return;
        }

        battleCont.board.interaction.DeMarkTiles ();

        if (battleCont.turnManager.enemiesLeft == 0 || battleCont.turnManager.heroesLeft == 0) {
            if (battleCont.turnManager.enemiesLeft == 0) {
                ChangeState (new CombatStateWin (this));
            } else if (battleCont.turnManager.heroesLeft == 0) {
                ChangeState (new CombatStateLose (this));
            }
        } else {
            battleCont.turnManager.AddUnit (battleCont.turnManager.CurrentUnit);
            ChangeState (new CombatStateUnit (this));
        }
    }

    public event EventHandler<UnitStateUpdate> UnitStateUpdated;

    protected virtual void OnUnitStateUpdated () {
        if (UnitStateUpdated != null)
            UnitStateUpdated (this, new UnitStateUpdate (UnitStateMachine));
    }

    public void UpdateUnitState () {
        OnUnitStateUpdated ();
    }
}

public class UnitStateUpdate : EventArgs {

    public UnitStateMachine UnitStateMachine { get; private set; }
    public TurnOrderObject Unit { get; private set; }

    public UnitStateUpdate (UnitStateMachine unitStateMachine) {
        this.UnitStateMachine = unitStateMachine;

        if (unitStateMachine != null) {
            this.Unit = unitStateMachine.unit.GetComponent<TurnOrderObject> ();
        }
    }
}