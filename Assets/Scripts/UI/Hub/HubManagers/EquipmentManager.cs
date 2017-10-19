//Description: Player presses either a inventory slot that represents a item in the players inventory or presses a inventory slot
             //representing a equipped item. The idea is that when the player clicks on a item in the player inventory this class
             //checks if the inventory slot indeed was a item of the players inventory or a equipment slot, it does this  with 
             //EquipmentClicked(). If it is a item in the players inventory it checks the .itemType of the <Item> and moves and 
             //displays the item at the correct equipment slot, this is done in EquipItem().
             //    It's a bit tricky when the player tries to equip a trinket because a trinket can be placed in two different
             //slots. A class, <TwoSlotChoices> is instatiated and two of the valid slots for trinkets are highligted and now the 
             //<EquipmentManager> is ready to move the selected trinket to one of the slots. If the player picks a invenotry
             //slot not valid for a trinket the trinket item will be selected and the equipment slot will be dehighlighted.
             //The ClickedInventorySlot() method in <TwoSlotChoice> gets what inventory slot the player clicked and what
             //how the game should react. 


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
    private TwoSlotChoice twoSlotChoiceInstance;

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
    public void RemoveEquipment(Item item) // << need to make another solution
    {
        for (int i = 0; i < equipment.AllPieces.Length; i++)
        {
            if(item == equipment.AllPieces[i])
            {
                equipment.AllPieces[i] = null;
            }
        }
    }
    public void EquipmentClicked(GameObject go, Item item)
    {
        //This method is called when the player clicks on an inventory slot that is in the barracks sub menu.
        foreach (GameObject gameobject in equipmentSlots) if (go = gameobject)
            {
                if (twoSlotChoiceInstance == null)
                { UnequipItem(go, item); return; }
                else
                { twoSlotChoiceInstance = new TwoSlotChoice(this, item); return; }
            }
        EquipItem(go, item); UnequipItem(go, item);
    }
    private void EquipItem(GameObject go, Item item)
    {
        barracksManager.playerInventory.Remove(item);
        {
            if (item.itemType == ItemType.Armor)
            {
                equipment.AllPieces[0] = item; equipmentSlots[0].GetComponent<InventorySlot>().AddItem(item);
            }
            else if (item.itemType == ItemType.OffHand)
            {
                if (!canDuelWield) { equipment.AllPieces[1] = item; equipmentSlots[1].GetComponent<InventorySlot>().AddItem(item); }
                else { /* call two slot choice*/}
            }
            else if (item.itemType == ItemType.Weapon)
            {
                if (!canDuelWield) { equipment.AllPieces[2] = item; equipmentSlots[2].GetComponent<InventorySlot>().AddItem(item); }
                else { /* call two slot choice*/}
            }
            else if (item.itemType == ItemType.Trinket)
            { twoSlotChoiceInstance = new TwoSlotChoice(this, item); } // < uses <TwoSlotChoice> cause a trinket 
        }                                                                          // can be placed in two different inventory slots.
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

                RemoveEquipment(item); //< Remove the item from the Equipment class.
            }

            index++;
        }
    }
    private void SelectedTwoSlotOption(GameObject go)
    {
        twoSlotChoiceInstance.ClickedInventorySlot(go);
    }
    //Properties
    public BarracksManager _BarracksManager { get { return barracksManager; } }
    public GameObject[] EquipmentSlots { get { return equipmentSlots; } }
    public Equipment _Equipment { get { return equipment; } set { equipment = value; } }
    public TwoSlotChoice TwoSlotChoiceInstance { get { return twoSlotChoiceInstance; } set { twoSlotChoiceInstance = value; } }
}
