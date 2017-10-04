using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIActionBarButton : MonoBehaviour {

	private Sprite defaultIcon;
	private Image icon;
	public Image cooldownImage;
	public Text cooldownText;
	private UIActionBarButtonDescription description;

	private AbilityCombat ability;

	private void Awake(){
		icon = GetComponent<Image>();
		defaultIcon = icon.sprite;
		description = GetComponentInChildren<UIActionBarButtonDescription>();		
	}

	public void SetupButton(AbilityCombat ability) {
		if(ability == null){
			return;
		}
		
		this.ability = ability;
		SetIcon(ability.ability.ability.icon);

		if(description != null){
			description.Setup(ability);
		}

		SetCooldown();
	}

	private void SetIcon(Sprite icon){
		this.icon.sprite = icon;
	}

	private void SetCooldown() {
		if(cooldownImage != null){
			cooldownImage.fillAmount = ability.Cooldown / ability.ability.ability.cooldown;
		}

		if(cooldownText != null) {
			cooldownText.text = (ability.Cooldown > 0) ? ability.Cooldown.ToString() : "";
		}
	}

	public void ResetIcon(){
		icon.sprite = defaultIcon;
	}
}
