using UnityEngine;

public class AbilitySlotPicked {

    private EquipmentManager equipmentManager;
    private int slot;

    private AbilitySlotPicked() { }
    public AbilitySlotPicked(
        EquipmentManager equipmentManager, int slot)
    {
        Debug.Log("RUNNING AbilitySlotPicked.cs");
        this.equipmentManager = equipmentManager;
        this.slot = slot;

        EquippingAbility();
        new UpdateUI(equipmentManager, true, false, false);
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
