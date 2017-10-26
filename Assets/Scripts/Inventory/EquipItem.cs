﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipItem 
{

    private EquipmentManager equipmentManager;
    private Item item;
    private BarracksManager barracksManager;
    private Equipment equipment;
    private GameObject[] equipmentSlots;
    private bool canDuelWield;
    private TwoSlotChoice twoSlotChoiceInstance;

    private EquipItem() { }
    public EquipItem(Item item, GameObject go, EquipmentManager equipmentManager)
    {
        Debug.Log("EquipItem RUNNING | EquipItem RUNNING | EquipItem RUNNING | EquipItem RUNNING |");
        this.item = item;
        this.equipmentManager = equipmentManager;
        equipment = equipmentManager.CurrentEquipment;
        equipmentSlots = equipmentManager.EquipmentSlots;
        canDuelWield = equipmentManager.CanDuelWield;
        twoSlotChoiceInstance = equipmentManager.TwoSlotChoiceInstance;

        Equip(go, item);
        Debug.Log("EquipItem DONE | EquipItem DONE | EquipItem DONE | EquipItem DONE | EquipItem DONE | ");

    }

    private void Equip(GameObject go, Item item)
    {
            equipmentManager._BarracksManager.playerInventory.Remove(item);
            
        
            if (item.itemType == ItemType.Armor)
            {
                Debug.Log("Equipping an Armor");
                equipment.EquipmentPieces[0] = item; equipmentSlots[0].GetComponent<InventorySlot>().AddItem(item);
            }
            else if (item.itemType == ItemType.OffHand)
            {
                Debug.Log("Equipping an OffHand");
                equipment.EquipmentPieces[1] = item; equipmentSlots[1].GetComponent<InventorySlot>().AddItem(item); 
               
            }
            else if (item.itemType == ItemType.Weapon)
            {
                if (!canDuelWield) { equipment.EquipmentPieces[2] = item; equipmentSlots[2].GetComponent<InventorySlot>().AddItem(item); }
                else { /* call two slot choice*/}
            }
            else if (item.itemType == ItemType.Trinket)
            { twoSlotChoiceInstance = new TwoSlotChoice(equipmentManager, item); } // < uses <TwoSlotChoice> cause a trinket 
                                                                                   //can be placed in two different inventory 
                                                                                    //slot.
        
    }                                                                              
}
