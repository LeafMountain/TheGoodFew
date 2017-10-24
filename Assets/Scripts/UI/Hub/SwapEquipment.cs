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
    private TwoSlotChoice twoSlotChoiceInstance;
    private bool clickedEquipmentSlot;

    private Item itemInQuestion;
    private GameObject inventorySlotOnButtonClicked;

    //Character details
    private bool canDuelWield;
    private UnitData.Class currentClass;

    private SwapEquipment() { } //Constructor
    public SwapEquipment(BarracksManager barracksManager, bool clickedEquipmentSlot, GameObject inventorySlot) //Constructor
    {
        Debug.Log("Swapping item");
        this.barracksManager = barracksManager;
        equipmentManager = barracksManager._EquipmentManager;
        
        twoSlotChoiceInstance = equipmentManager.TwoSlotChoiceInstance;
        this.clickedEquipmentSlot = clickedEquipmentSlot;

        itemInQuestion = barracksManager.ItemInQuestion;
        inventorySlotOnButtonClicked = inventorySlot;

        InventoryClicked(inventorySlotOnButtonClicked, itemInQuestion);
      
    }
    public void InventoryClicked(GameObject go, Item item)
    {
        //This method is called when the player clicks on an inventory slot that is in the barracks sub menu.
        if (clickedEquipmentSlot)
        {
            Debug.Log("You clicked a EquipmentSlot");

             new UnequipItem(go, item, equipmentManager); 
        }
        else
        {
            Debug.Log("You clicked a inventory slot");
            
            new EquipItem(item, go, equipmentManager);
        }
    }
}


