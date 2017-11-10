using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiSlotChoice {

    private EquipmentManager equipmentManager;
    private BarracksManager barracksManager;
    private AbilityDataOffensive abilityBeingEquipped;

    private InventorySlot abilitySlotOne;
    private InventorySlot abilitySlotTwo;
    private InventorySlot abilitySlotThree;
    private InventorySlot abilitySlotFour;
    private InventorySlot abilitySlotFive;

    private MultiSlotChoice() { }
    public MultiSlotChoice(
        EquipmentManager equipmentManager, 
        AbilityDataOffensive ability)
    {

        Debug.Log("Running MultuSlotChoice.cs");
        this.equipmentManager = equipmentManager;
        barracksManager = equipmentManager._BarracksManager;

        abilityBeingEquipped = ability;

        equipmentManager.MultiSlotChoiceInstance = this;
        barracksManager.WaitForSlotPicked = true;

        GameObject[] slots = equipmentManager.AbilitySlots;

        
        abilitySlotOne = slots[0].GetComponent<InventorySlot>();
        abilitySlotTwo = slots[1].GetComponent<InventorySlot>();
        abilitySlotThree = slots[2].GetComponent<InventorySlot>();
        abilitySlotFour = slots[3].GetComponent<InventorySlot>();
        abilitySlotFive = slots[4].GetComponent<InventorySlot>();

        HighlightSlots(true);

    }
    public void HighlightSlots(bool light)
    {
        foreach(GameObject go in equipmentManager.AbilitySlots)
        {
            go.GetComponent<InventorySlot>().HightlightSelf(light);
        }
    }
    public AbilityDataOffensive AbilityBeingEquipped {
        get { return abilityBeingEquipped; } }
        
}
