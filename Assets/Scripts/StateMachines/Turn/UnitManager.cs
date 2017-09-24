using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 

public class UnitManager:MonoBehaviour {

	private static UnitManager currentInstance;
	public List < TurnOrderObject > turnOrderObjects; 

	public static UnitManager GetInstance(){
		return currentInstance;
	}

	private void Start() {
		currentInstance = this;
		FindTurnOrderObjects();
	}

	//Find all TurnOrderObjects and add them to the list of turn order objects.
	private void FindTurnOrderObjects() {
		TurnOrderObject[] turnOrderObjects = (TurnOrderObject[])GameObject.FindObjectsOfType(typeof(TurnOrderObject)); 
		this.turnOrderObjects.AddRange(turnOrderObjects); 
	}

	//Add unit to list of units (removes units from list if the list already contains the unit)
	public void AddUnit(TurnOrderObject unit) {
		RemoveUnit(unit); 
		turnOrderObjects.Add(unit); 
	}

	//Remove units from list of units
	public void RemoveUnit(TurnOrderObject unit) {
		if (turnOrderObjects.Contains(unit)) {
			turnOrderObjects.Remove(unit); 
		}
		else {
			Debug.Log("The unit doesn't exists in the Turn Order Object list"); 
		}
	}
}
