using UnityEngine;

public class AbilitySlotPicked {

    private EquipmentManager equipmentManager;
    private int slot;

    private AbilitySlotPicked() { }
    public AbilitySlotPicked(
        EquipmentManager equipmentManager, int slot)
    {
        this.equipmentManager = equipmentManager;
        this.slot = slot;

        EquippingAbility();
    }

    private void EquippingAbility()
    {
        new EquipAbility(
            equipmentManager._BarracksManager.AbilityInQuestion,
            null, equipmentManager, slot);
        equipmentManager.MultiSlotChoiceInstance = null;
        equipmentManager._BarracksManager.
            WaitForSlotPicked = false;

        foreach(GameObject go in equipmentManager.AbilitySlots)
        {
            go.GetComponent<InventorySlot>().HightlightSelf(false);
        }
    }
}
