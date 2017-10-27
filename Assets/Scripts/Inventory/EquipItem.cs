using UnityEngine;

public class EquipItem 
{

    private EquipmentManager equipmentManager;
    private Item item;
    private BarracksManager barracksManager;
    private Equipment equipment;
    private GameObject[] equipmentSlots;
    private bool canDuelWield;
    private TwoSlotChoice twoSlotChoiceInstance;
    private Inventory playerInventory;

    private EquipItem() { }
    public EquipItem(Item item, GameObject go, EquipmentManager equipmentManager)
    {
        Debug.Log("EquipItem RUNNING | EquipItem RUNNING | EquipItem RUNNING | EquipItem RUNNING |");
        this.item = item;
        this.equipmentManager = equipmentManager;
        equipment = equipmentManager.CurrentEquipment;
        equipmentSlots = equipmentManager.EquipmentSlots;
        canDuelWield = equipmentManager.CanDuelWield;
        twoSlotChoiceInstance = equipmentManager.TwoSlotChoiceInstance;
        playerInventory = equipmentManager._BarracksManager.playerInventory;

        Equip(go, item);
        Debug.Log("EquipItem DONE | EquipItem DONE | EquipItem DONE | EquipItem DONE | EquipItem DONE | ");

    }
    public EquipItem(int equipmentSlot, Item item, EquipmentManager equipmentManager)
    {
        Debug.Log("Equipping " + item.ToString());
        this.equipmentManager = equipmentManager;
        GameObject slot = equipmentManager.EquipmentSlots[equipmentSlot];
        Inventory playerInventory = equipmentManager._BarracksManager.playerInventory;
        Item currentlyEquippedItem = equipmentManager.EquipmentSlots[equipmentSlot].GetComponent<InventorySlot>()._Item;

        if (currentlyEquippedItem != null)
        {
            new MoveItemBetweenInventoryAndEquipmentSlot(currentlyEquippedItem, slot, playerInventory);
        }
            new MoveItemBetweenInventoryAndEquipmentSlot(item, playerInventory, slot);

        equipmentManager.CurrentEquipment.EquipmentPieces[equipmentSlot] = item;
       
        equipmentManager.TwoSlotChoiceInstance.Highligt(false);
        equipmentManager.TwoSlotChoiceInstance = null;
        equipmentManager._BarracksManager.WaitForSlotPicked = false;
        equipmentManager._BarracksManager._InventoryUI.UpdateUI();
        
    }

    private void Equip(GameObject go, Item item)
    {
            if (item.itemType == ItemType.Armor)
            {
                Debug.Log("Equipping an Armor");
                equipment.EquipmentPieces[0] = item;
                 new MoveItemBetweenInventoryAndEquipmentSlot(item, playerInventory, go); 
            }
            else if (item.itemType == ItemType.OffHand)
            {
                Debug.Log("Equipping an OffHand");
                equipment.EquipmentPieces[1] = item;
                new MoveItemBetweenInventoryAndEquipmentSlot(item, playerInventory, go);


            }
             else if (item.itemType == ItemType.Weapon)
            {
                Debug.Log("Equipping a Weapon");
                if (!canDuelWield) { equipment.EquipmentPieces[2] = item;
                new MoveItemBetweenInventoryAndEquipmentSlot(item, playerInventory, go);
            }
            else { /* call two slot choice*/}
            }
            else if (item.itemType == ItemType.Trinket)
            {
                Debug.Log("Equipping a Trinket");
                twoSlotChoiceInstance = new TwoSlotChoice(equipmentManager, item);
            }                                                                       // < uses <TwoSlotChoice> cause a trinket 
                                                                                   //can be placed in two different inventory 
                                                                                    //slot.
        
    }
}
