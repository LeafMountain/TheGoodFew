using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIActionBar : MonoBehaviour {

	private List<UIActionBarButton> buttons = new List<UIActionBarButton>();
	private UnitManager unitManager;

	private void Start(){
		FindButtons();
		unitManager = UnitManager.GetInstance();
		unitManager.TurnOrderUpdated += OnTurnOrderUpdated;
		// unitManager.TurnOrderUpdated += OnTurnOrderUpdated;
	}

	private void FindButtons(){
		buttons.AddRange(GetComponentsInChildren<UIActionBarButton>());
	}

	private void OnTurnOrderUpdated(object source, TurnOrderUpdate turnOrderUpdate){
		// ResetButtons();
		Debug.Log(turnOrderUpdate.CurrentUnit.GetComponent<ObjectInformation>().Abilities.Count);
	}

	private void SetupButtons(List<Ability> abilities){
		for(int i = 0; i < buttons.Count; i++){
			if(abilities[i] != null){
				buttons[i].SetIcon(abilities[i].ability.icon);
			} else {
				buttons[i].ResetIcon();
			}
		}
	}

	public void ResetButtons(){
		for(int i = 0; i < buttons.Count; i++){
			buttons[i].ResetIcon();
		}
	}
}
