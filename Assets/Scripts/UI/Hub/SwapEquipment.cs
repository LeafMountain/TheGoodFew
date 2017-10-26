//Description: When the player adds or removes a item used as equipment this class is called. When a Button with 
//an <InventorySlot> class on it is clicked this class may be instantiated if the player is in the 
//barracks manu. The <InventorySlot> tells the <BarracksManager> that it was clicked.
//Type: Controller
using UnityEngine;

public class SwapEquipment {

    private BarracksManager barracksManager;
    private EquipmentManager equipmentManager;
    private TwoSlotChoice twoSlotChoiceInstance;
    private bool clickedEquipmentSlot;

    private Item itemBeingEquipped;
    private Item itemBeingSwapped;
    private GameObject inventorySlotOnButtonClicked;

    //Character details
    private bool canDuelWield;
    private UnitData.Class currentClass;

    private SwapEquipment() { } //Constructor
    public SwapEquipment(EquipmentManager equipmentManager) //Constructor
    {
        Debug.Log("SwapEquipment RUNNING | SwapEquipment RUNNING | SwapEquipment RUNNING | SwapEquipment RUNNING  ");
        this.equipmentManager = equipmentManager;
        
        twoSlotChoiceInstance = equipmentManager.TwoSlotChoiceInstance;
        itemBeingEquipped = equipmentManager._BarracksManager.ItemInQuestion;
        

        SwapItems();
        Debug.Log("SwapEquipment DONE | SwapEquipment DONE | SwapEquipment DONE | SwapEquipment DONE ");
    }
    public void SwapItems()
    {
        if (equipmentManager.EquipmentSlots[WhatSlotIsBeingSwapped(itemBeingEquipped)].GetComponent<InventorySlot>()._Item != null)
        {
            itemBeingSwapped = equipmentManager.EquipmentSlots[WhatSlotIsBeingSwapped(itemBeingEquipped)].GetComponent<InventorySlot>()._Item;
            Debug.Log("Replacing " + itemBeingSwapped.ToString() + " with " + itemBeingEquipped.ToString());

            new UnequipItem(equipmentManager.EquipmentSlots[WhatSlotIsBeingSwapped(itemBeingEquipped)], itemBeingSwapped, equipmentManager);
        }
        else
        {
            Debug.Log("There is no item to replace.");
        }
    }

    private int WhatSlotIsBeingSwapped(Item item)
    {
        if (item.itemType == ItemType.Armor) return 0;
        else if (item.itemType == ItemType.OffHand) return 1;
        else if (!canDuelWield && item.itemType == ItemType.Weapon) return 2;

        return -1;
    }
    private void AskWhatSlotToUnequip() //This is used when the player equips a trinket. The player can choose trinket slot one or two.
    {

    }
}


