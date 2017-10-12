using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnStatePrepare : ITurnState {

	private TurnStateMachine turnStateMachine;

	public TurnStatePrepare (TurnStateMachine turnStateMachine){
		this.turnStateMachine = turnStateMachine;
	}

	public void EnterState(){
		turnStateMachine.TurnManager = TurnController.GetInstance();
	}

	public void ExitState(){

	}

	public void Update(){
		turnStateMachine.ChangeState(new TurnStateNewTurn(turnStateMachine));
	}
	
}
