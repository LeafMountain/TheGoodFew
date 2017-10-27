//Description: This class is used when the player wants to unequip an item. 
using UnityEngine;

public class UnequipItem {

    private EquipmentManager equipmentManager;
    private Equipment equipment;
    private GameObject[] equipmentSlots;

    public UnequipItem(GameObject go, Item item, EquipmentManager equipmentManager)
    {
        Debug.Log("UnequipItem RUNNING | UnequipItem RUNNING | UnequipItem RUNNING | UnequipItem RUNNING ");

        this.equipmentManager = equipmentManager;
        equipment = equipmentManager.CurrentEquipment;
        equipmentSlots = equipmentManager.EquipmentSlots;

        Unequip(go, item);

        Debug.Log("UnequipItem DONE | UnequipItem DONE | UnequipItem DONE | UnequipItem DONE ");

    }

    private void Unequip(GameObject go, Item item)
    {
        if (go.GetComponent<InventorySlot>()._Item != null)
        {
            Debug.Log("Unequiping " + item.name);

            new MoveItemBetweenInventoryAndEquipmentSlot(item, go, equipmentManager._BarracksManager.playerInventory);
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
