using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability {
    public AbilityDataActive ability { get; private set; }
    public bool usingAbility { get; set; }
    public int cooldown { get; private set; }

    public Ability (AbilityDataActive ability) {
        this.ability = ability;
    }

    //Start the cooldown at the abilitys default cooldown or the inputed value
    public void StartCooldown (int manualValue = 0) {
        if (manualValue == 0)
            cooldown = ability.cooldown;
        else
            cooldown = manualValue;
    }

    //Reduces the cooldown by 1 or the inputed value
    public void ReduceCooldown (int manualValue = 0) {
        if (cooldown != 0) {
            if (manualValue == 0)
                cooldown--;
            else
                cooldown -= manualValue;

            if (cooldown < 0)
                cooldown = 0;
        }
    }

}
