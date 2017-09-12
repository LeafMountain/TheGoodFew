using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityDescriptionFrame : MonoBehaviour {

    [SerializeField] private Text title;
    [SerializeField] private Text dmg;
    [SerializeField] private Text mDmg;
    [SerializeField] private Text heal;
    [SerializeField] private Text range;
    [SerializeField] private Text description;

    //Updates the ability description for the hover information in game
    public void SetValues (Ability ability) {
        AbilityDataOffensive offensiveAbility = (AbilityDataOffensive) ability.ability;
        title.text = ability.ability.title;

        dmg.text = "Dmg: " + offensiveAbility.physicalDamage.ToString ();
        dmg.enabled = (offensiveAbility.physicalDamage != 0);

        mDmg.text = "MDmg: " + offensiveAbility.magicalDamage.ToString ();
        mDmg.enabled = (offensiveAbility.magicalDamage != 0);

        heal.text = "Heal: " + offensiveAbility.heal.ToString ();
        heal.enabled = (offensiveAbility.heal != 0);

        range.text = "Range: " + offensiveAbility.range.ToString ();

        description.text = offensiveAbility.description;
    }

}