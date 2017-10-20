using System; 
using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 

public class TurnController : CombatElement {
	private InputController inputManager;

	private void Start(){
		inputManager = InputController.GetInstance();
		if(inputManager){
			inputManager.NextPressed += OnNewUnit;
		}
	}

	//Add unit to list of units (removes units from list if the list already contains the unit)
	public void AddUnit(UnitModel unit) {
		App.Model.TurnModel.AddUnit(unit);
		OnNewTurnOrder();
		OnNewUnit();
	}

	//Remove units from list of units
	public void RemoveUnit(UnitModel unit) {
		App.Model.TurnModel.RemoveUnit(unit);
	}

	public List<UnitModel> GetTurnOrder(){
		return App.Model.TurnModel.GetTurnOrder();
	}

	public UnitModel GetCurrentUnit(){
		return App.Model.TurnModel.GetTurnOrder()[0];
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
			// NewTurn.Invoke(App.Model.TurnModel.turnOrder);
		}
	}

	protected virtual void OnNewTurnOrder(){
		if(NewTurnOrder != null){
			// NewTurnOrder.Invoke(App.Model.TurnModel.turnOrder);
		}
	}

	protected virtual void OnNewUnit(){
		if(NewUnit != null){
			// NewUnit.Invoke(App.Model.TurnModel.turnOrder[0]);
		}
	}

#endregion
}