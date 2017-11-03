using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatApplication : MonoBehaviour {

	public CombatController Controller { get; private set; }
	public CombatModel Model { get; private set; }

	private void Awake(){
		Model = new CombatModel();		
		Controller = new CombatController(this);
	}
}
