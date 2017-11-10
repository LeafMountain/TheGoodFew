using UnityEngine;

public class AbilitySlotClicked {

    private BarracksManager barracksManager;
    private ShopManager shopManager;
    private AbilityDataOffensive ability;

    public AbilitySlotClicked(
        BarracksManager barracksManager, AbilityDataOffensive ability, GameObject gameObject)
    {
        Debug.Log("RUNNING AbilitySlotClicked.cs");
        this.barracksManager = barracksManager;
        shopManager = null;
        this.ability = ability;

        barracksManager.AbilityInQuestion = ability;
        barracksManager.SlotClicked(gameObject, null, ability);
    }
   
}
