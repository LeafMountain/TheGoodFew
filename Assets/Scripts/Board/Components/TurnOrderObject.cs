using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOrderObject : MonoBehaviour {

	public enum Allegiance { Enemy, Friendly }
	public Allegiance allegiance;

<<<<<<< HEAD:Assets/Scripts/CombatUnitComponents/TurnOrderObject.cs
<<<<<<< HEAD:Assets/Scripts/CombatUnitComponents/TurnOrderObject.cs
	private TurnManager unitManager;
	private TurnManager UnitManager { 
=======
	private UnitManager unitManager;
	private UnitManager UnitManager { 
>>>>>>> parent of 0bf2840... Merge pull request #11 from LeafMountain/TGF-130-ActivateUnit:Assets/Scripts/Board/Components/TurnOrderObject.cs
		get {
			if(unitManager == null){
				unitManager = UnitManager.GetInstance();
			}
			return unitManager;
		}
	}

<<<<<<< HEAD:Assets/Scripts/CombatUnitComponents/TurnOrderObject.cs
	public delegate void UnitEvent ();

	public event UnitEvent TurnStarted;


=======
	private TurnManager turnManager;

	private void Start(){
		Health health = GetComponent<Health>();

		if (health)
		{
			health.Dead.AddListener(OnDead);
		}
	}

	//If unit dies, disables the gameobject
>>>>>>> parent of e6a0ca8... Merge pull request #3 from LeafMountain/TGF-101-TurnStateMachine:Assets/Scripts/Board/Components/TurnOrderObject.cs
=======
>>>>>>> parent of 0bf2840... Merge pull request #11 from LeafMountain/TGF-130-ActivateUnit:Assets/Scripts/Board/Components/TurnOrderObject.cs
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
