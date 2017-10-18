using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EquipmentPart { Body, OffHand, MainHand, FirstTrinket, SecondTrinket}

public class EquipmentManager {

    private BarracksManager barracksManager;

    private UnitData currentCharacter; //< the current character in the barracks. 

    private GameObject[] equipmentSlots;
    private Equipment equipment;

    private bool canDuelWield; //<< Future ability.

    private EquipmentManager() { }
    public EquipmentManager(BarracksManager barracksManager)
    {
        this.barracksManager = barracksManager;
        equipmentSlots = new GameObject[5];
        for (int i = 0; i < barracksManager.playerEquipment.transform.childCount; i++)
        {
            equipmentSlots[i] = barracksManager.playerEquipment.transform.GetChild(i).gameObject;
        }
    }
    public void RemoveEquipment(EquipmentPart part)
    {
        equipment.AllPieces[(int)part] = null;
    }
    public void EquipmentSlotClicked(GameObject go, Item item)
    {
        //This method is called when the player clicks on an inventory slot that is in the barracks sub menu.
        foreach (GameObject gameobject in equipmentSlots) if (go = gameobject) { UnequipItem(go, item); return; }
        EquipItem(item); UnequipItem(go, item);
    }
    private void EquipItem(Item item)
    {
        barracksManager.playerInventory.Remove(item);
        if (item.itemType == ItemType.Armor)
        {
            equipment.AllPieces[0] = item; equipmentSlots[0].GetComponent<InventorySlot>().AddItem(item);
        }
        else if (item.itemType == ItemType.OffHand)
        { if (!canDuelWield) { equipment.AllPieces[1] = item; equipmentSlots[1].GetComponent<InventorySlot>().AddItem(item); }
        else { /* call two slot choice*/}
        }
        else if (item.itemType == ItemType.Weapon)
        { if (!canDuelWield) { equipment.AllPieces[2] = item; equipmentSlots[2].GetComponent<InventorySlot>().AddItem(item); }
            else { /* call two slot choice*/}
        }
        else if (item.itemType == ItemType.Trinket)
        { new TwoSlotChoice(this, item.itemType); } // < uses <TwoSlotChoice> cause a trinket can be placed in two
                                                    // different inventory slots.
    }

    private void UnequipItem(GameObject go, Item item)
    {
        int index = 0;
        foreach(GameObject gameobject in equipmentSlots) //Matches the GO with the equipment slots array in this class.
        {
            if(go == gameobject)
            {
                go.GetComponent<InventorySlot>().RemoveItemFromInventory(); //< Remove from the Inventory Slot.
                barracksManager.playerInventory.Add(item); //< Add the removed item to the player inventory.

                RemoveEquipment((EquipmentPart)index); //< Remove the item from the Equipment class.
            }

            index++;
        }
    }
    
    //Properties
    public BarracksManager _BarracksManager { get { return barracksManager; } }
    public GameObject[] EquipmentSlots { get { return equipmentSlots; } }
}
