using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIActionBarButtonDescription : MonoBehaviour {

	public Text title;
	public Text dmg;
	public Text mDmg;
	public Text heal;
	public Text range;
	public Text info;

	public void Setup(AbilityCombat ability){
		title.text = ability.ability.ability.name;
		info.text = ability.ability.ability.description;
	}
	
	private void Awake(){
		gameObject.SetActive(false);
	}
}
