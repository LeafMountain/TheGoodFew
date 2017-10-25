using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStateIdle_Random : UnitStateIdle {

    public float actionDelay = 1f;

    public UnitStateIdle_Random (UnitStateMachine stateMachine) : base (stateMachine) { }

    public override void EnterState () {
        stateMachine.FocusCamera ();

    }

    private IEnumerator GoToMoveState () {
        yield return new WaitForSeconds (actionDelay);
        stateMachine.ChangeState (new UnitStateMove_Random (stateMachine));

    }

    public override void Update () {
        actionDelay -= Time.deltaTime;

        if (actionDelay < 0)
            stateMachine.ChangeState (new UnitStateMove_Random (stateMachine));

    }
}