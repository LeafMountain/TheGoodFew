using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatController : CombatElement {

	public BoardController boardController;
	public TurnController turnController;
	public PathfindingController pathfindingController;

	private void Awake(){
		boardController = GetComponentInChildren<BoardController>();
		turnController = GetComponentInChildren<TurnController>();
		pathfindingController = GetComponentInChildren<PathfindingController>();
	}
}
