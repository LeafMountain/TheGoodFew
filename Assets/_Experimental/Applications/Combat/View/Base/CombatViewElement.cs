using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatViewElement : MonoBehaviour {

	private static CombatApplication app;
	public CombatApplication App { 
		get{
			if(app == null){
				app = GameObject.FindObjectOfType(typeof(CombatApplication)) as CombatApplication;

				if(app == null){
					Debug.LogError("Scene need a combat application.");
				}
			}

			return app;
		}
	}
}
