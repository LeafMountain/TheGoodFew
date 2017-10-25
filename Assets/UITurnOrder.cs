using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITurnOrder : MonoBehaviour {

	private List<UITurnOrderPortrait> portraits = new List<UITurnOrderPortrait>();

	private void Start(){
		portraits.AddRange(GetComponentsInChildren<UITurnOrderPortrait>());
		TurnManager.GetInstance().TurnOrderUpdated += OnTurnOrderUpdated;
	}

	private void OnTurnOrderUpdated (object source, TurnOrderUpdate turnOrderUpdate) {
        SetTurnOrderList (turnOrderUpdate.TurnOrder);		
    }
	
	public void SetTurnOrderList(List<TurnOrderObject> turnOrderObjects){
		for (int i = 0; i < portraits.Count; i++)
		{
			portraits[i].SetPortrait(turnOrderObjects[i].GetComponent<ObjectInformation>().UnitData.portrait);
		}
	}
}
