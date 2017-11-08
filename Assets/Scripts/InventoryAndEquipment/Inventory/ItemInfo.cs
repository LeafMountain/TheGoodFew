public class ItemInfo {

    private InventorySlot inventorySlot;
    private bool show;

    public ItemInfo(InventorySlot inventorySlot, bool show)
    {
        this.inventorySlot = inventorySlot;
        this.show = show;

        if (show) { ShowItemInfo(); }
        else { RemoveItemInfo(); }
    }
    private void ShowItemInfo()
    {
        if (inventorySlot._Item != null)
        {
            if (inventorySlot._ShopManager != null)
            {
                inventorySlot._ShopManager.informationDisplay.
                    RecieveInformation(inventorySlot._Item);
            }
            else
            {
                inventorySlot._BarracksManager.informationDisplay.
                    RecieveInformation(inventorySlot._Item);
            }
        }
    }
    private void RemoveItemInfo()
    {
        if (inventorySlot._ShopManager != null)
        {
            inventorySlot._ShopManager.
                informationDisplay.EmptyDisplay();
        }
        else
        {
            inventorySlot._BarracksManager.
                informationDisplay.EmptyDisplay();
        }
    }
}
