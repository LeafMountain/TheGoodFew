using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnStateNewTurn : StateMachineState {

	private TurnStateMachine turnStateMachine;

	public TurnStateNewTurn(TurnStateMachine stateMachine){
		turnStateMachine = stateMachine;
	}

	public override void EnterState () {
		
	}

	public void ExitState(){
		TurnOrderObject currentUnit = turnStateMachine.UnitManager.CurrentUnit;
		turnStateMachine.UnitManager.AddUnit(currentUnit);
	}

	public void Update(){

		//Use input manager instead for input.
		if(Input.GetKeyDown(KeyCode.Space)){
			turnStateMachine.ChangeState(new TurnStateNewTurn(turnStateMachine));
		}
	}
	
}
