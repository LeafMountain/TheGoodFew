using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatModel : CombatElement {

	public TurnModel turnModel;
	public BoardModel boardModel;

	private void Awake(){
		turnModel = GetComponentInChildren<TurnModel>();
		boardModel = GetComponentInChildren<BoardModel>();
	}
}
