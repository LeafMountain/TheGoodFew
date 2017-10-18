//Description: This class is used when the player wants to equip a trinket 
//Type: Controller 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoSlotChoice {

    private EquipmentManager equipmentManager;
    private BarracksManager barracksManager;
    private Color highlightColor;
    private ItemType itemTypeInQuestion;

    private InventorySlot slotOne;
    private InventorySlot slotTwo;

    private TwoSlotChoice() { }
    public TwoSlotChoice(EquipmentManager equipmentManager, ItemType itemtype)
    {
        this.equipmentManager = equipmentManager;
        barracksManager = equipmentManager._BarracksManager;
        highlightColor = Color.yellow;
        itemTypeInQuestion = itemtype;

        if (itemTypeInQuestion == ItemType.Trinket)
        {
            slotOne = equipmentManager.EquipmentSlots[3].GetComponent<InventorySlot>();
            slotTwo = equipmentManager.EquipmentSlots[4].GetComponent<InventorySlot>();
        }
        else
        {
            slotOne = equipmentManager.EquipmentSlots[1].GetComponent<InventorySlot>();
            slotTwo = equipmentManager.EquipmentSlots[2].GetComponent<InventorySlot>();
        }
    }
    private void Highligt()
    {
        slotOne.HightlightSelf(true);
        slotOne.HightlightSelf(true);
    }
    


}
