public class Clicked  {

    private InventorySlot inventorySlot;
    private bool inShopMode;

    public Clicked(InventorySlot inventorySlot)
    {
        this.inventorySlot = inventorySlot;

        if (!inventorySlot.IsAbilitySlot) { ClickedInventorySlot(); }
        else { ClickedAbilitySlot(); }
    }
    private void ClickedInventorySlot()
    {
        if (inventorySlot._Item != null)
        {
            if (inventorySlot._ShopManager != null)
            {
                new InventorySlotClicked(
                    inventorySlot._ShopManager, inventorySlot._Item);

            }
            else
            {
                if (!inventorySlot._BarracksManager.WaitForSlotPicked)
                {
                    new InventorySlotClicked(
                        inventorySlot._BarracksManager, inventorySlot._Item,
                        inventorySlot.gameObject);
                }
                else
                {
                    inventorySlot._BarracksManager._EquipmentManager.
                        EquipmentSlotPicked(
                        inventorySlot.transform.GetSiblingIndex());
                }
            }
        }
    }
    private void ClickedAbilitySlot()
    {
        if(inventorySlot.Ability != null)
        {
            new AbilitySlotClicked(inventorySlot._BarracksManager,
                inventorySlot.Ability, inventorySlot.gameObject);
        }
    }

}
