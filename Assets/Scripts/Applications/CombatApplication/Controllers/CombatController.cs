using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatController : CombatElement {

	public BoardController Board { get; private set; }
	public TurnController TurnController { get; private set; }
	public Pathfinder Pathfinder { get; private set; }

	private void Awake(){
		Board = GetComponentInChildren<BoardController>();
		TurnController = GetComponentInChildren<TurnController>();
		Pathfinder = new Pathfinder();
	}
}
