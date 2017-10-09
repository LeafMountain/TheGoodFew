using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnStateNewTurn : ITurnState {

	private TurnStateMachine turnStateMachine;
	private TurnOrderObject currentUnit;

	public TurnStateNewTurn(TurnStateMachine turnStateMachine){
		this.turnStateMachine = turnStateMachine;
	}

	public void EnterState(){

	}

	public void ExitState(){
		currentUnit = turnStateMachine.TurnManager.CurrentUnit;
		turnStateMachine.TurnManager.AddUnit(currentUnit);
	}

	public void Update(){

		//Use input manager instead for input.
		if(Input.GetKeyDown(KeyCode.Space)){
			turnStateMachine.ChangeState(new TurnStateNewTurn(turnStateMachine));
		}
	}

	private void FocusCamera(){
		CameraControls.GetInstance().Move(currentUnit.transform.position);
	}
}
