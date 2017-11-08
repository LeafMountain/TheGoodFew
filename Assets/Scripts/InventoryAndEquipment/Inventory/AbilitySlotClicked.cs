using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySlotClicked : MonoBehaviour {

    private BarracksManager barracksManager;
    private ShopManager shopManager;
    private AbilityDataOffensive ability;

    public AbilitySlotClicked(
        BarracksManager barracksManager, AbilityDataOffensive ability, GameObject gameObject)
    {
        this.barracksManager = barracksManager;
        shopManager = null;
        this.ability = ability;

        barracksManager.AbilityInQuestion = ability;
        barracksManager.SlotClicked(gameObject, null, ability);
    }
   
}
