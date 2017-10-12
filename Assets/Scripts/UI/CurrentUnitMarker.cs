using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentUnitMarker : MonoBehaviour {

	private TurnManager turnManager;

	private void Start(){
		turnManager = TurnManager.GetInstance();
		turnManager.NewUnit += SetParent;
	}

	private void SetParent(TurnOrderObject currentUnit){
		transform.SetParent(currentUnit.transform);
	}
}
