using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOrderObject : MonoBehaviour {

	public enum Allegiance { Enemy, Friendly }
	public Allegiance allegiance;

	private TurnManager unitManager;
	private TurnManager UnitManager { 
		get {
			if(unitManager == null){
				unitManager = TurnManager.GetInstance();
			}
			return unitManager;
		}
	}

	public delegate void UnitEvent ();

	public event UnitEvent TurnStarted;


	private void OnDead(){
		gameObject.SetActive(false);
	}

	private void OnEnable(){
		UnitManager.AddUnit(this);
	}

	private void OnDisable(){
		UnitManager.RemoveUnit(this);
	}

	public void StartTurn(){
		if(TurnStarted != null){
			TurnStarted.Invoke();
		}
	}
}
