using System; 
using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 

public class TurnManager:MonoBehaviour {

	private static TurnManager currentInstance; 
	public List < TurnOrderObject > turnOrderObjects = new List<TurnOrderObject>();
	public TurnOrderObject CurrentUnit {get {return turnOrderObjects[0]; }}


	public static TurnManager GetInstance() {
		return currentInstance;
	}

	private void Awake() {
		currentInstance = this;
	}

	private void Start() {
		OnTurnOrderUpdated();
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
		OnTurnOrderUpdated();
	}

	//Remove units from list of units
	public void RemoveUnit(TurnOrderObject unit) {
		if (turnOrderObjects.Contains(unit)) {
			turnOrderObjects.Remove(unit);
			OnTurnOrderUpdated();
		}
		else {
			Debug.Log("The unit doesn't exists in the Turn Order Object list");
		}
	}

	//Event
	public event EventHandler<TurnOrderUpdate> TurnOrderUpdated;
	
	//Trying to make an event for when a new turn starts
	public delegate void TurnEvent ();
	public event TurnEvent NewTurn;


	protected virtual void OnTurnOrderUpdated () {		
		if (TurnOrderUpdated != null) {
			TurnOrderUpdated (this, new TurnOrderUpdate (turnOrderObjects)); 
		}
	}

	protected virtual void OnNewTurn(){
		if(NewTurn != null){
			NewTurn.Invoke();
		}
	}
}

public class TurnOrderUpdate:EventArgs {
	public List < TurnOrderObject > TurnOrderList {get; private set; }
	public TurnOrderObject CurrentUnit {get {return TurnOrderList[0]; }}
	
	public TurnOrderUpdate (List < TurnOrderObject > newTurnOrder) {
		this.TurnOrderList = newTurnOrder; 
	}
}
