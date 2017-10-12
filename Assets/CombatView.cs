using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatView : CombatElement {

	public BoardView boardView;

	private void Awake(){
		boardView = GetComponentInChildren<BoardView>();
	}
}
