using UnityEngine;

public class InventorySlotClicked  {

    private BarracksManager barracksManager;
    private ShopManager shopManager;
    private Item item;
    private AbilityDataOffensive ability;

    public InventorySlotClicked(
        BarracksManager barracksManager, Item item, GameObject gameObject)
    {
        this.barracksManager = barracksManager;
        shopManager = null;
        this.item = item;

        barracksManager.ItemInQuestion = item;
        barracksManager.SlotClicked(gameObject, item, null);
    }
    public InventorySlotClicked(ShopManager shopManager, Item item)
    {
        barracksManager = null;
        this.shopManager = shopManager;
        this.item = item;

        shopManager.ItemInQuestion = this.item;
        shopManager.Ask(item.itemName, item.price);
    }
    
}
