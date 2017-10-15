using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITurnOrder : MonoBehaviour {

	private List<UITurnOrderPortrait> portraits = new List<UITurnOrderPortrait>();

	private void Start(){
		portraits.AddRange(GetComponentsInChildren<UITurnOrderPortrait>());
		// TurnController.GetInstance().NewTurnOrder += OnNewTurnOrder;
	}

	private void OnNewTurnOrder (List<TurnOrderObject> turnOrder) {
        SetTurnOrderList (turnOrder);
    }
	
	private void SetTurnOrderList(List<TurnOrderObject> turnOrderObjects){
		for (int i = 0; i < portraits.Count; i++) {
			portraits[i].SetPortrait(turnOrderObjects[i].GetComponent<ObjectInformation>().UnitData.portrait);
		}
	}
}
