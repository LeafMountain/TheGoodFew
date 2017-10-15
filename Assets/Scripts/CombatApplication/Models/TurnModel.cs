using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnModel {

	private List<UnitModel> turnOrder = new List<UnitModel>();

	public void AddUnit(UnitModel unit){
		if(turnOrder.Contains(unit)){
			RemoveUnit(unit);
		}
		turnOrder.Add(unit);
	}

	public void RemoveUnit(UnitModel unit){
		turnOrder.Remove(unit);
	}

	public List<UnitModel> GetTurnOrder(){
		return turnOrder;
	}
	
}
