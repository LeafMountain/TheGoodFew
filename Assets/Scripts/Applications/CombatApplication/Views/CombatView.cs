using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatView : CombatElement {

	public BoardView BoardView { get; private set; }

	private void Awake(){
		BoardView = GetComponentInChildren<BoardView>();
	}
}
