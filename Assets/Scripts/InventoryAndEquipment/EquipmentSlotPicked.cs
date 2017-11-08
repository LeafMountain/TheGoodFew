public class EquipmentSlotPicked {

    private EquipmentManager equipmentManager;
    private int slot;

    public EquipmentSlotPicked(
        EquipmentManager equipmentManager, int slot)
    {
        this.equipmentManager = equipmentManager;
        this.slot = slot;

        if(equipmentManager._BarracksManager.
            ItemInQuestion.itemType == ItemType.Trinket)
        {
            EquippingTrinket();
        }
        else
        {
            EquippingWeapon();
            new UpdateUI(equipmentManager, false, true, true);
        }

       
    }
    private void EquippingTrinket()
    {
        if(slot >= 3)
        {
            new EquipItem(
                slot, equipmentManager._BarracksManager.
                ItemInQuestion, equipmentManager);
        }
        else
        {
            equipmentManager._BarracksManager.playerInventory.
                Add(
                equipmentManager._BarracksManager.ItemInQuestion);
            equipmentManager._BarracksManager.ItemInQuestion = null;
        }
    }
    private void EquippingWeapon()
    {
        if(slot == 1 || slot == 2)
            {
            new EquipItem(slot, equipmentManager._BarracksManager.
                ItemInQuestion, equipmentManager);
        }
        else
        {
            equipmentManager._BarracksManager.playerInventory.
                Add(
                equipmentManager._BarracksManager.ItemInQuestion);
            equipmentManager._BarracksManager.ItemInQuestion = null;
        }
    }

}
