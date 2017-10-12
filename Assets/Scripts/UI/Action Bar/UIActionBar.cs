using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIActionBar : MonoBehaviour {

	private List<UIActionBarButton> buttons = new List<UIActionBarButton>();
	private TurnController turnManager;

	private void Start(){
		FindButtons();
		turnManager = TurnController.GetInstance();
		turnManager.NewUnit += OnNewUnit;
	}

	private void FindButtons(){
		buttons.AddRange(GetComponentsInChildren<UIActionBarButton>());
	}

	private void OnNewUnit(TurnOrderObject currentUnit){
		ResetButtons();

		AbilityUser currentAbilityUser = currentUnit.GetComponent<AbilityUser>();

		if(currentAbilityUser != null){
			SetupButtons(currentUnit.GetComponent<AbilityUser>().Abilities);
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
