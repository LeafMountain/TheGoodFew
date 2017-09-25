using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOrderObject : MonoBehaviour {

	public enum Allegiance { Enemy, Friendly }
	public Allegiance allegiance;

	private UnitManager unitManager;
	private UnitManager UnitManager { 
		get {
			if(unitManager == null){
				unitManager = UnitManager.GetInstance();
			}
			return unitManager;
		}
	}

	private void OnDead(){
		gameObject.SetActive(false);
	}

	private void OnEnable(){
		UnitManager.AddUnit(this);
	}

	private void OnDisable(){
		UnitManager.RemoveUnit(this);
	}
}
