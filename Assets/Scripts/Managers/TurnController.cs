using System; 
using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 

public class TurnController : CombatElement {
	private static TurnController currentInstance; 

	private InputManager inputManager;


	public static TurnController GetInstance() {
		return currentInstance;
	}

	private void Awake() {
		currentInstance = this;
	}

	private void Start(){
		inputManager = InputManager.GetInstance();
		if(inputManager){
			inputManager.NextPressed += OnNewUnit;
		}
	}

	//Find all TurnOrderObjects and add them to the list of turn order objects.
	private void FindTurnOrderObjects() {
		TurnOrderObject[] turnOrderObjects = (TurnOrderObject[])GameObject.FindObjectsOfType(typeof(TurnOrderObject));
		App.model.turnModel.turnOrder.AddRange(turnOrderObjects);
	}

	//Add unit to list of units (removes units from list if the list already contains the unit)
	public void AddUnit(TurnOrderObject unit) {
		RemoveUnit(unit); 
		App.model.turnModel.turnOrder.Add(unit);
		OnNewTurnOrder();
		OnNewUnit();
	}

	//Remove units from list of units
	public void RemoveUnit(TurnOrderObject unit) {
		Debug.Log(App.model);
		if (App.model.turnModel.turnOrder.Contains(unit)) {
			App.model.turnModel.turnOrder.Remove(unit);
			OnNewTurnOrder();
		}
		else {
			Debug.Log("The unit doesn't exists in the Turn Order Object list");
		}
	}

#region [Events]
	//Turn Events
	public delegate void TurnEvent (List<TurnOrderObject> turnOrderObjects);
	public event TurnEvent NewTurn;
	public event TurnEvent NewTurnOrder;

	//Unit Event
	public delegate void UnitEvent(TurnOrderObject currentUnit);
	public event UnitEvent NewUnit;

	protected virtual void OnNewTurn(){
		if(NewTurn != null){
			NewTurn.Invoke(App.model.turnModel.turnOrder);
		}
	}

	protected virtual void OnNewTurnOrder(){
		if(NewTurnOrder != null){
			NewTurnOrder.Invoke(App.model.turnModel.turnOrder);
		}
	}

	protected virtual void OnNewUnit(){
		if(NewUnit != null){
			NewUnit.Invoke(App.model.turnModel.turnOrder[0]);
		}
	}

#endregion
}