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

using UnityEngine;

public enum EquipmentPart { Body, OffHand, MainHand, FirstTrinket, SecondTrinket}

public class EquipmentManager {

    private BarracksManager barracksManager;
    private GameObject[] equipmentSlots;
    private Equipment currentEquipment;

    private bool canDuelWield; //<< Future ability.
    private UnitData currentCharacter; //< the current character in the barracks. 

    private TwoSlotChoice twoSlotChoiceInstance; 

    private EquipmentManager() { }//Constructor
    public EquipmentManager(BarracksManager barracksManager)
    {
        this.barracksManager = barracksManager;
        equipmentSlots = new GameObject[5];
        for (int i = 0; i < barracksManager.playerEquipment.transform.childCount; i++)
        {
            equipmentSlots[i] = barracksManager.playerEquipment.transform.GetChild(i).gameObject;
        }
    } // Constructor
    public void InventorySlotClicked(GameObject go)
    {
        bool clickedEquipmentSlot = false;
        
        for (int i = 0; i < equipmentSlots.Length; i++)
        {
            if(equipmentSlots[i] == go){ clickedEquipmentSlot = true; }
        }
        if (clickedEquipmentSlot)
        {
            Debug.Log("You clicked an EquipmentSlot");

            new UnequipItem(go, barracksManager.ItemInQuestion, this);
        }
        else
        {
                Debug.Log("You clicked an inventory slot");
           
                new SwapEquipment(this);
            
                new EquipItem(barracksManager.ItemInQuestion, go, this);
        }
    }
    public void UpdateEquipmentUI()
    {
        if (currentEquipment != null)
        {
            for (int i = 0; i < equipmentSlots.Length; i++)
            {
                if (currentEquipment.EquipmentPieces[i] != null)
                {
                    equipmentSlots[i].GetComponent<InventorySlot>().AddItem(currentEquipment.EquipmentPieces[i]);
                }
            }
        }
    }
    public void EquipmentSlotPicked(int slot)
    {
        if(barracksManager.ItemInQuestion.itemType == ItemType.Trinket)
        {
            if (slot >= 3)
            {
                new EquipItem(slot, barracksManager.ItemInQuestion, this);
            }
            else
            {
                barracksManager.playerInventory.Add(barracksManager.ItemInQuestion);
                barracksManager.ItemInQuestion = null;
            }
        }
        else
        {
            if(slot == 1 || slot == 2)
            {
                new EquipItem(slot, barracksManager.ItemInQuestion, this);
            }
            else
            {
                barracksManager.playerInventory.Add(barracksManager.ItemInQuestion);
                barracksManager.ItemInQuestion = null;
            }
            UpdateEquipmentUI();
            _BarracksManager._InventoryUI.UpdateUI();
        }
    }
    //Properties
    public BarracksManager _BarracksManager { get { return barracksManager; } }
    public GameObject[] EquipmentSlots { get { return equipmentSlots; } }
    public Equipment CurrentEquipment { get { return currentEquipment; } set { currentEquipment = value; } }
    public TwoSlotChoice TwoSlotChoiceInstance { get { return twoSlotChoiceInstance; } set { twoSlotChoiceInstance = value; } }
    public bool CanDuelWield { get { return canDuelWield; } }
}
