using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentUnitMarker : MonoBehaviour {

	private TurnManager turnManager;

	private void Start(){
		turnManager = TurnManager.GetInstance();
		turnManager.TurnOrderUpdated += SetParent;
	}

	private void SetParent(object source, TurnOrderUpdate turnOrderUpdate){
		transform.SetParent(turnOrderUpdate.currentUnit.transform);
	}
}
