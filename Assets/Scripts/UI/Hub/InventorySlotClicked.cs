using UnityEngine;

public class InventorySlotClicked  {

    private BarracksManager barracksManager;
    private ShopManager shopManager;
    private Item item;
    private AbilityDataOffensive ability;

    public InventorySlotClicked(
        BarracksManager barracksManager, Item item, GameObject gameObject)
    {
        Debug.Log("InventorySlotClicked.sc "+
            "FIRST constructor.");
        this.barracksManager = barracksManager;
        shopManager = null;
        this.item = item;

        barracksManager.ItemInQuestion = item;
        barracksManager.SlotClicked(gameObject, item, null);
    }
    public InventorySlotClicked(ShopManager shopManager, Item item)
    {
        Debug.Log("InventorySlotClicked.sc " +
            "SECOND constructor.");
        barracksManager = null;
        this.shopManager = shopManager;
        this.item = item;

        shopManager.ItemInQuestion = this.item;
        shopManager.Ask(item.itemName, item.price);
    }
    public InventorySlotClicked(
        BarracksManager barracksManager, AbilityDataOffensive ability,
        GameObject gameObject)
    {
        Debug.Log("InventorySlotClicked.sc " +
            "THIRD constructor.");
        this.barracksManager = barracksManager;
        this.ability = ability;
        item = null;
        shopManager = null;

        barracksManager.AbilityInQuestion = ability;
        barracksManager.SlotClicked(gameObject, null, ability);
    }
    
}
