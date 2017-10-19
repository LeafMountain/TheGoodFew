//Description: When the player adds or removes a item used as equipment this class is called. When a Button with 
            //an <InventorySlot> class on it is clicked this class may be instantiated if the player is in the 
            //barracks manu. The <InventorySlot> tells the <BarracksManager> that it was clicked.
//Type: Component
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapEquipment {

    private BarracksManager barracksManager;
    private EquipmentManager equipmentManager;
    private Equipment equipment;
    private GameObject[] equipmentSlots;
    private TwoSlotChoice twoSlotChoiceInstance;
    private bool clickedEquipmentSlot;

    //Character details
    private bool canDuelWield;
    private UnitData.Class currentClass;



    private SwapEquipment() { }
    public SwapEquipment(BarracksManager barracksManager, bool clickedEquipmentSlot)
    {
        this.barracksManager = barracksManager;
        equipmentManager = barracksManager._EquipmentManager;
        equipment = equipmentManager._Equipment;
        equipmentSlots = equipmentManager.EquipmentSlots;
        canDuelWield = equipmentManager.CanDuelWield;
        twoSlotChoiceInstance = equipmentManager.TwoSlotChoiceInstance;
        this.clickedEquipmentSlot = clickedEquipmentSlot;
    }
    public void InventoryClicked(GameObject go, Item item)
    {
        //This method is called when the player clicks on an inventory slot that is in the barracks sub menu.
        foreach (GameObject gameobject in equipmentSlots)
            if (go = gameobject)
            {
                if (twoSlotChoiceInstance == null)
                { UnequipItem(go, item); return; }
                else
                { twoSlotChoiceInstance = new TwoSlotChoice(equipmentManager, item); return; }
            }
        EquipItem(go, item); UnequipItem(go, item);
    }
    private void UnequipItem(GameObject go, Item item)
    {
        int index = 0;
        foreach (GameObject gameobject in equipmentSlots) //Matches the GO with the equipment slots array in this class.
        {
            if (go == gameobject)
            {
                go.GetComponent<InventorySlot>().RemoveItemFromInventory(); //< Remove from the Inventory Slot.
                barracksManager.playerInventory.Add(item); //< Add the removed item to the player inventory.
                RemoveEquipment(item); //< Remove the item from the Equipment class.
            }
            index++;
        }
    }
    private void EquipItem(GameObject go, Item item)
    {
        barracksManager.playerInventory.Remove(item);
        {
            if (item.itemType == ItemType.Armor)
            {
                equipment.allPieces[0] = item; equipmentSlots[0].GetComponent<InventorySlot>().AddItem(item);
            }
            else if (item.itemType == ItemType.OffHand)
            {
                if (!canDuelWield) { equipment.allPieces[1] = item; equipmentSlots[1].GetComponent<InventorySlot>().AddItem(item); }
                else { /* call two slot choice*/}
            }
            else if (item.itemType == ItemType.Weapon)
            {
                if (!canDuelWield) { equipment.allPieces[2] = item; equipmentSlots[2].GetComponent<InventorySlot>().AddItem(item); }
                else { /* call two slot choice*/}
            }
            else if (item.itemType == ItemType.Trinket)
            { twoSlotChoiceInstance = new TwoSlotChoice(equipmentManager, item); } // < uses <TwoSlotChoice> cause a trinket 
        }                                                                           //can be placed in two different inventory 
    }                                                                               //slots.
    private  void RemoveEquipment(Item item)
    {
        for (int i = 0; i < equipment.allPieces.Length; i++)
        {
            if (item == equipment.allPieces[i])
            {
                equipment.allPieces[i] = null;
            }
        }
    }
}

