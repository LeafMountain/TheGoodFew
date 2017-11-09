using UnityEngine;

public class Clicked  {

    private InventorySlot inventorySlot;
    private bool inShopMode;
    private InventorySlotType type;

    public Clicked(InventorySlot inventorySlot)
    {
        this.inventorySlot = inventorySlot;
        type =
            inventorySlot.SlotType;

        if (type == InventorySlotType.InventorySlot)
        { ClickedInventorySlot(); }

        else if(type == InventorySlotType.AbilitySlot)
        { ClickedAbilitySlot(); }
        else if(type == InventorySlotType.EquipmentSlot)
        { ClickedEquipmentSlot(); }
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
    private void ClickedEquipmentSlot()
    {
        Debug.Log("Clicked.CLickedEquipmentSlotSlot()");

        if (!inventorySlot._BarracksManager.WaitForSlotPicked)
        {
            inventorySlot._BarracksManager.SlotClicked(
                inventorySlot.gameObject, inventorySlot._Item, null);
        }
        else
        {
            inventorySlot._BarracksManager._EquipmentManager.
                       EquipmentSlotPicked(
                       inventorySlot.transform.GetSiblingIndex());
        }
    }

}
