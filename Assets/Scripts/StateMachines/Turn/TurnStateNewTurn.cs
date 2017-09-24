using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnStateNewTurn : ITurnState {

	private TurnStateMachine turnStateMachine;

	public TurnStateNewTurn(TurnStateMachine turnStateMachine){
		this.turnStateMachine = turnStateMachine;
	}

	public void EnterState(){
	}

	public void ExitState(){
		turnStateMachine.UnitManager.AddUnit(turnStateMachine.UnitManager.turnOrderObjects[0]);
	}

	public void Update(){
		// Debug.Log(turnStateMachine.UnitManager.turnOrderObjects.Count);	

	}
}
