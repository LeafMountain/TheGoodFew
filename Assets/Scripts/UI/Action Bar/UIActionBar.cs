using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIActionBar : MonoBehaviour {

	private List<UIActionBarButton> buttons = new List<UIActionBarButton>();
	private TurnManager unitManager;

	private void Start(){
		FindButtons();
		unitManager = TurnManager.GetInstance();
		unitManager.TurnOrderUpdated += OnTurnOrderUpdated;
	}

	private void FindButtons(){
		buttons.AddRange(GetComponentsInChildren<UIActionBarButton>());
	}

	private void OnTurnOrderUpdated(object source, TurnOrderUpdate turnOrderUpdate){
		ResetButtons();

		AbilityUser currentAbilityUser = unitManager.CurrentUnit.GetComponent<AbilityUser>();

		if(currentAbilityUser != null){
			SetupButtons(unitManager.CurrentUnit.GetComponent<AbilityUser>().Abilities);
		}
	}

	private void SetupButtons(List<AbilityCombat> abilities){
		for(int i = 0; i < buttons.Count; i++){
			if(i < abilities.Count && abilities[i] != null){
				buttons[i].SetupButton(abilities[i]);
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
