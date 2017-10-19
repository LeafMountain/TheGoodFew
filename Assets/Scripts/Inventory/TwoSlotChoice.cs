//Description: This class is used when the player wants to equip a trinket 
//Type: Controller 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoSlotChoice {

    private EquipmentManager equipmentManager;
    private BarracksManager barracksManager;
    private Color highlightColor;
    private Item twoChoiceItem;
    private ItemType itemTypeInQuestion;

    private InventorySlot slotOne;
    private InventorySlot slotTwo;

    private TwoSlotChoice() { }
    public TwoSlotChoice(EquipmentManager equipmentManager, Item item)
    {
        this.equipmentManager = equipmentManager;
        barracksManager = equipmentManager._BarracksManager;
        twoChoiceItem = item;
        itemTypeInQuestion = item.itemType;

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
    public void ClickedInventorySlot(GameObject go)
    { 
     //This method is called when the player presses a inventory slot while the variable twoSlotChoiceInstance is not
     //null. It looks if the player clicked a valid equipment slot (inventory slot) for the item being equipped.
    Item item = twoChoiceItem;

    barracksManager.playerInventory.Remove(item);
        int index = 0;
        foreach(GameObject gameobject in equipmentManager.EquipmentSlots)
        {
            if(itemTypeInQuestion == ItemType.Trinket)
            {
                if(gameobject == go)
                {
                    equipmentManager._Equipment.allPieces[index] = item;
                    equipmentManager.EquipmentSlots[index].GetComponent<InventorySlot>().AddItem(item);
                }       
            }
        }
        equipmentManager.TwoSlotChoiceInstance = null;
    }
    
    public ItemType ItemTypeInQuestion { get { return itemTypeInQuestion; } }
    public Item TwoChoiceItem { get { return twoChoiceItem; } }
}
