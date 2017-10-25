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

	private void Start(){
		Health health = GetComponent<Health>();

		if (health)
		{
			health.Dead.AddListener(OnDead);
		}
	}

	//If unit dies, disables the gameobject
	private void OnDead(){
		gameObject.SetActive(false);
	}

	//Add gameobject to turn manager when this component gets enabled
	private void OnEnable(){
		turnManager = TurnManager.GetInstance();
		
		if(turnManager != null){
			turnManager.AddUnit(this);
		}
	}

	//Remove gameobject from turn manager when this component gets disabled
	private void OnDisable(){
		if(turnManager != null){
			turnManager.RemoveUnit(this);
		}
	}
}
