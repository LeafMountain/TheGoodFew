using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityButton : MonoBehaviour {
    private AbilityManager abilityManager;
    private AbilityFrame abilityFrame;
    public Button abilityButton { get; private set; }
    public Image abilityIcon { get; private set; }
    public Text abilityCooldownText { get; private set; }
    public Image abilityCooldownFade;
    public Sprite defaultAbilityIcon { get; private set; }

    private AbilityDescriptionFrame description;

    private void Awake () {
        abilityManager = GetComponentInParent<AbilityManager>();
        abilityFrame = GetComponentInParent<AbilityFrame>();
        abilityButton = GetComponent<Button>();
        abilityIcon = GetComponent<Image>();
        abilityCooldownText = GetComponentInChildren<Text>();
        description = GetComponentInChildren<AbilityDescriptionFrame>();
        description.gameObject.SetActive(false);


        defaultAbilityIcon = abilityIcon.sprite;
    }

    //Updates the button to show the correct ability information
    public void UpdateAbility (Ability ability) {
        //Reset slot
        ClearSlot();

        //Set correct cooldown text
        if (ability.cooldown == 0) {
            abilityCooldownText.text = "";
        }
        else {
            abilityCooldownText.text = ability.cooldown.ToString();
        }

        //Set icon
        abilityIcon.sprite = ability.ability.icon;

        //Set cooldown overlay
        abilityCooldownFade.fillAmount = (float)ability.cooldown / (float)ability.ability.cooldown;

        //Set description values
        description.SetValues(ability);

        //If the ability is in a using state, change the color to red and make it exit using state when clicked again
        if (ability.usingAbility) {
            abilityButton.onClick.AddListener(() => abilityManager.ResetAbility());
            abilityCooldownFade.fillAmount = 1;
            abilityCooldownFade.color = new Color(255, 0, 0, 0.7f);
        }
        //If the ability is off cooldown, make it useable
        else if (ability.cooldown == 0) {
            abilityButton.onClick.AddListener(() => abilityManager.UseAbility(abilityFrame.unit.GetComponent<TurnOrderObject>(), ability));
        }
    }

    //Resets everythin to the default layout
    public void ClearSlot () {
        abilityCooldownText.text = null;
        abilityIcon.sprite = defaultAbilityIcon;
        abilityCooldownFade.fillAmount = 0;
        abilityCooldownFade.color = new Color(0, 0, 0, 0.7f);
        abilityButton.onClick.RemoveAllListeners();
    }
}
