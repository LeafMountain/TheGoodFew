using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatEventTracker : MonoBehaviour {

	private static CombatEventTracker instance;

	private CameraControls cameraControls;

	public Vector3 EventPosition { get; private set; }

	public static CombatEventTracker GetInstance(){
		return instance;
	}

	private void Awake(){
		instance = this;
	}

	public void Start(){
		cameraControls = CameraControls.GetInstance();
		UnitManager.GetInstance().TurnOrderUpdated += OnTurnOrderUpdated;
	}

	public void SetEventPosition(Vector3 position){
		EventPosition = position;
	}

	public void OnTurnOrderUpdated(object source, TurnOrderUpdate turnOrderUpdate){
		SetEventPosition(turnOrderUpdate.CurrentUnit.transform.position);
		OnCombatEventUpdated();
	}

	//Event
	public event EventHandler<CombatEventTrackerUpdate> CombatEventUpdated;

	protected virtual void OnCombatEventUpdated () {
		if (CombatEventUpdated != null) {
			CombatEventUpdated (this, new CombatEventTrackerUpdate(EventPosition)); 
		}
	}
}

public class CombatEventTrackerUpdate:EventArgs {
	public Vector3 eventPosition;
	
	public CombatEventTrackerUpdate (Vector3 position) {
		eventPosition = position;
	}
}
