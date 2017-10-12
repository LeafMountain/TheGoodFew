using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityUser : MonoBehaviour {

	private List<AbilityCombat> abilities = new List<AbilityCombat>();
	public List<AbilityCombat> Abilities { get{ return abilities; } }

	private void Start(){
		CreateAbilities();
		TurnOrderObject turnOrderObject = GetComponent<TurnOrderObject>();

		if(turnOrderObject != null){
			turnOrderObject.ActiveUnit += OnTurnStart;
		}
	}

	private void CreateAbilities() {
		ObjectInformation objectInformation = GetComponent<ObjectInformation>();

		if(objectInformation == null){
			return;
		}
		
		for (int i = 0; i < objectInformation.Abilities.Count; i++) {
			abilities.Add(new AbilityCombat(objectInformation.Abilities[i]));
		}
	}

	private void OnTurnStart(){
		for (int i = 0; i < abilities.Count; i++) {
			abilities[i].ReduceCooldown();
		}
	}
	
}
