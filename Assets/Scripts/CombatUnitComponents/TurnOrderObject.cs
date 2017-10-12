using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOrderObject : MonoBehaviour {

	public enum Allegiance { Enemy, Friendly }
	public Allegiance allegiance;

	private TurnManager turnManager;
	private TurnManager TurnManager { 
		get {
			if(turnManager == null){
				turnManager = TurnManager.GetInstance();
			}
			return turnManager;
		}
	}

	private void OnDead(){
		gameObject.SetActive(false);
	}

	private void OnEnable(){
		TurnManager.AddUnit(this);
		TurnManager.NewUnit += OnUnitActivated;
		TurnManager.NewTurn += OnNewTurn;
	}

	private void OnDisable(){
		TurnManager.RemoveUnit(this);
		TurnManager.NewUnit -= OnUnitActivated;
		TurnManager.NewTurn -= OnNewTurn;
	}

#region [Events]
	public delegate void UnitEvent ();

	public event UnitEvent UnitActivated;
	public event UnitEvent UnitInactivated;
	public event UnitEvent NewTurn;

	private void OnUnitActivated(TurnOrderObject currentUnit){
		if(currentUnit == this && UnitActivated != null){
			UnitActivated.Invoke();
		}
	}

	private void OnUnitInactivated(TurnOrderObject currentUnit){
		if(currentUnit == this && UnitActivated != null){
			UnitActivated.Invoke();
		}
	}

	private void OnNewTurn(List<TurnOrderObject> turnOrder){
		if(NewTurn != null){
			NewTurn.Invoke();
		}
	}

#endregion

}
