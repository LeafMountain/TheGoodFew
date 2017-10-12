using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatElement : MonoBehaviour { 
	private CombatApplication app;
	public CombatApplication App {
		get {
			if(!app){
				app = (CombatApplication)FindObjectOfType(typeof(CombatApplication));
			}
			return app;
		}
	}
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
