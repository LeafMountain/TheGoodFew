using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentUnitMarker : MonoBehaviour {

	private TurnController turnManager;

	private void Start(){
		turnManager = TurnController.GetInstance();
		turnManager.NewUnit += SetParent;
	}

	private void SetParent(TurnOrderObject currentUnit){
		transform.SetParent(currentUnit.transform);
	}
}
