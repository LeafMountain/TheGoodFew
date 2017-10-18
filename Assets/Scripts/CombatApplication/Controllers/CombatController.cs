using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatController : CombatElement {

	public BoardController Board { get; private set; }
	public TurnController TurnController { get; private set; }
	public PathfindingController PathfindingController { get; private set; }
	public PathfindingController1 pathfindingController1 = new PathfindingController1();

	private void Awake(){
		Board = GetComponentInChildren<BoardController>();
		TurnController = GetComponentInChildren<TurnController>();
		PathfindingController = GetComponentInChildren<PathfindingController>();
	}
}
