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
        Debug.Log("SwapEquipment RUNNING | SwapEquipment RUNNING" + 
            " | SwapEquipment RUNNING | SwapEquipment RUNNING  ");
        this.equipmentManager = equipmentManager;
        
        twoSlotChoiceInstance = equipmentManager.TwoSlotChoiceInstance;
        itemBeingEquipped = equipmentManager._BarracksManager.ItemInQuestion;
        

        SwapItems();
        Debug.Log("SwapEquipment DONE | SwapEquipment DONE |" +
            " SwapEquipment DONE | SwapEquipment DONE ");
    }
    public void SwapItems()
    {
        if (WhatSlotIsBeingSwapped(itemBeingEquipped) != -1)
        {
            if (equipmentManager.
                EquipmentSlots[WhatSlotIsBeingSwapped(itemBeingEquipped)].
                GetComponent<InventorySlot>()._Item != null)
            {
                itemBeingSwapped = 
                    equipmentManager.
                    EquipmentSlots[WhatSlotIsBeingSwapped(itemBeingEquipped)].
                    GetComponent<InventorySlot>()._Item;
                Debug.Log("Replacing " + itemBeingSwapped.ToString() + 
                    " with " + itemBeingEquipped.ToString());

                new UnequipItem(
                    equipmentManager.
                    EquipmentSlots[WhatSlotIsBeingSwapped(itemBeingEquipped)],
                    itemBeingSwapped, equipmentManager);
            }
            else
            {
                Debug.Log("There is no item to replace.");

            }
        }
      }

    private int WhatSlotIsBeingSwapped(Item item)
    {
        if (item.itemType == ItemType.Armor) return 0;
        else if (item.itemType == ItemType.OffHand) return 1;
        else if (!canDuelWield && item.itemType == ItemType.Weapon) return 2;
        else if (item.itemType == ItemType.Trinket) return -1;

        return -1;
    }
}


