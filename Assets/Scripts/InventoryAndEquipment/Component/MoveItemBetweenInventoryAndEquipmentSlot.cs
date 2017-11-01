//Description: Simple class that moves an item from or to a equipment slot. 
//              Use the first constructor to move an item from 
//              the player inventory to an equipments slot and use 
//              the second one to move an item from an equipment slot to 
//              the player inventory.
using UnityEngine;

public class MoveItemBetweenInventoryAndEquipmentSlot {


    private MoveItemBetweenInventoryAndEquipmentSlot() { }
    public MoveItemBetweenInventoryAndEquipmentSlot(
        Item item, Inventory from, GameObject to)
    {
        Debug.Log("Moving " + item.ToString() + " to " 
            + to.ToString() + " from " + from.ToString());
        from.Remove(item);
        to.GetComponent<InventorySlot>().AddItem(item);
    }
    public MoveItemBetweenInventoryAndEquipmentSlot(
        Item item, GameObject from, Inventory to)
    {
        Debug.Log("Moving " + item.ToString() +
            " to " + to.ToString() + " from " + from.ToString());
        from.GetComponent<InventorySlot>().ClearSlot();
        to.Add(item);
    }
    
}
