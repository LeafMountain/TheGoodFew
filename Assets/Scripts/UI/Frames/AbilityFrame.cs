using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityFrame : MonoBehaviour {
    public ObjectInformation unit { get; private set; }
    [SerializeField] private AbilityButton weaponAbility;
    [SerializeField] private AbilityButton ability1;
    [SerializeField] private AbilityButton ability2;
    [SerializeField] private AbilityButton ability3;
    [SerializeField] private AbilityButton ability4;
    [SerializeField] private AbilityButton ability5;
    [SerializeField] private Sprite usingAbilitySprite;

    private List<AbilityButton> abilityButtons = new List<AbilityButton> ();

    public void Start () {
        AddAbilityButtons ();

        (FindObjectOfType (typeof (AbilityManager)) as AbilityManager).AbilityManagerUpdated += OnAbilityManagerUpdated;
        gameObject.SetActive (false);
    }

    //Add the UI buttons to a list
    private void AddAbilityButtons () {
        abilityButtons.Add (weaponAbility);
        abilityButtons.Add (ability1);
        abilityButtons.Add (ability2);
        abilityButtons.Add (ability3);
        abilityButtons.Add (ability4);
        abilityButtons.Add (ability5);
    }

    private void OnAbilityManagerUpdated (object source, AbilityManagerUpdate update) {
        unit = update.user;

        //If the unit is not player controlled, hide UI
        if (unit != null && unit.UnitData.type == UnitData.UnitType.hostile) {
            gameObject.SetActive (false);
        }
        //Show UI and update buttons with the correct icons, cooldowns and description
        else {
            gameObject.SetActive (true);
            if (update.abilities != null && update.abilities.Count > 0) {
                for (int i = 0; i < abilityButtons.Count; i++) {
                    if (i < update.abilities.Count) {
                        AddNewAbility (abilityButtons[i], update.abilities[i]);
                    } else {
                        abilityButtons[i].ClearSlot ();
                    }
                }
            }
        }
    }

    //Add ability to button if the ability is not null
    private void AddNewAbility (AbilityButton button, Ability ability) {
        if (ability != null) {
            button.UpdateAbility (ability);
        } else {
            button.ClearSlot ();
        }
    }
}