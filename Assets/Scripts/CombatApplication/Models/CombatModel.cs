using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatModel : CombatElement {

	private TurnModel turnModel = new TurnModel();
	public TurnModel TurnModel { get{ return turnModel; } }

	private BoardModel boardModel = new BoardModel();	
	public BoardModel Board { get { return boardModel; } }

}
