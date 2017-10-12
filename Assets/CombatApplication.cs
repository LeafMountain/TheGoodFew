using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatElement : MonoBehaviour { 

	public CombatApplication app = (CombatApplication)FindObjectOfType(typeof(CombatApplication));
}

public class CombatApplication : MonoBehaviour {

	public CombatController controller;
	public CombatModel model;
	public CombatView view;
	
	private void Awake(){
		controller = GetComponentInChildren<CombatController>();
		model = GetComponentInChildren<CombatModel>();
		view = GetComponentInChildren<CombatView>();
	}
}
