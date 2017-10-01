using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityCombat {
	public Ability ability { get; private set; }
	private int cooldown;	
	public int Cooldown { 
		get{
			return cooldown;
		}
		private set{
			if(value > 0){
				cooldown = value;
			}
			else {
				cooldown = 0;
			}
		} 
	}

	public AbilityCombat(Ability ability){
		this.ability = ability;
		Cooldown = 0;
	}

	public void StartCooldown(){
		Cooldown = ability.ability.cooldown;
	}

	public void ReduceCooldown(int amount = 1){
		Cooldown -= 1;
	}

	public void ModifyCooldown(int modifyAmount){
		Cooldown += modifyAmount;
	}
}
