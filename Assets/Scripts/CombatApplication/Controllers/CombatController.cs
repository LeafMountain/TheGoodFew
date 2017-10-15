using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatController : CombatElement {

	public BoardController BoardController { get; private set; }
	public TurnController TurnController { get; private set; }
	public PathfindingController PathfindingController { get; private set; }

	private void Awake(){
		BoardController = GetComponentInChildren<BoardController>();
		TurnController = GetComponentInChildren<TurnController>();
		PathfindingController = GetComponentInChildren<PathfindingController>();
	}
}
