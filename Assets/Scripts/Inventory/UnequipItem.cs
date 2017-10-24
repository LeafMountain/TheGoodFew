using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnequipItem {

    private EquipmentManager equipmentManager;
    private Equipment equipment;
    private GameObject[] equipmentSlots;

    public UnequipItem(GameObject go, Item item, EquipmentManager equipmentManager)
    {
        this.equipmentManager = equipmentManager;
        equipment = equipmentManager.CurrentEquipment;
        equipmentSlots = equipmentManager.EquipmentSlots;

    }
    private void Unequip(GameObject go, Item item)
    {
        if (go.GetComponent<InventorySlot>()._Item != null)
        {
            Debug.Log("Unequiping " + item.name);

            go.GetComponent<InventorySlot>().RemoveItemFromInventory(); //< Remove from the Inventory Slot.
            equipmentManager._BarracksManager.playerInventory.Add(item); //< Add the removed item to the player inventory.
            RemoveEquipment(go, item); //< Remove the item from the Equipment class.
        }
        else
        {
            Debug.Log("There is no item to unequip.");
        }
    }
    private void RemoveEquipment(GameObject go, Item item)
    {
        Debug.Log("Removing equipment piece for " + (EquipmentPart)(go.transform.GetSiblingIndex()));
        equipment.EquipmentPieces[go.transform.GetSiblingIndex()] = null;
    }

}
