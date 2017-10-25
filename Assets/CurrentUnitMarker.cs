using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentUnitMarker : MonoBehaviour {

	private UnitManager unitManager;

	private void Start(){
		unitManager = UnitManager.GetInstance();
		unitManager.TurnOrderUpdated += SetParent;
	}

	private void SetParent(object source, TurnOrderUpdate turnOrderUpdate){
		transform.SetParent(turnOrderUpdate.CurrentUnit.transform);
	}
}
