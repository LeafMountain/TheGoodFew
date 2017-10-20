using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSetupController : CombatElement {

	private void Awake(){
		FindTurnOrderObjects();
	}

	private void Start(){
		PlaceUnits();
	}

	//Find all TurnOrderObjects and add them to the list of turn order objects.
	private void FindTurnOrderObjects() {
		TurnOrderObject[] turnOrderObjects = (TurnOrderObject[])GameObject.FindObjectsOfType(typeof(TurnOrderObject));

		for (int i = 0; i < turnOrderObjects.Length; i++){
			App.Model.TurnModel.AddUnit(new UnitModel(null, turnOrderObjects[i], App.Controller.Board.GetCell(new Vector2(turnOrderObjects[i].transform.position.x, turnOrderObjects[i].transform.position.z))));
		}
	}

	private void PlaceUnits(){
		for (int i = 0; i < App.Model.TurnModel.GetTurnOrder().Count; i++)
		{
			UnitModel unit = App.Model.TurnModel.GetTurnOrder()[i];
			TileModel tile = unit.CurrentTile;
			tile.SetUnit(unit);
		}
	}

}
