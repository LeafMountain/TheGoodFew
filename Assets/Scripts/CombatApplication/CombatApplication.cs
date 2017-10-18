using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatElement : MonoBehaviour { 
	private static CombatApplication app;
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

	public CombatController Controller { get; private set; }
	public CombatModel Model { get; private set; }
	public CombatView View { get; private set; }
	
	private void Awake(){
		Controller = GetComponentInChildren<CombatController>();
		Model = GetComponentInChildren<CombatModel>();
		View = GetComponentInChildren<CombatView>();
	}
}
