﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnStateNewTurn : StateMachineState {

	public override void EnterState () {
		
	}

<<<<<<< HEAD
	public void ExitState(){
		TurnOrderObject currentUnit = turnStateMachine.UnitManager.CurrentUnit;
		turnStateMachine.UnitManager.AddUnit(currentUnit);
	}

	public void Update(){

		//Use input manager instead for input.
		if(Input.GetKeyDown(KeyCode.Space)){
			turnStateMachine.ChangeState(new TurnStateNewTurn(turnStateMachine));
		}
=======
	public override void ExitState(){
		
	}
	
	public override void Update () {
		
>>>>>>> parent of c11bb99... TurnStateMachine update and Unit Manager
	}
	
}
