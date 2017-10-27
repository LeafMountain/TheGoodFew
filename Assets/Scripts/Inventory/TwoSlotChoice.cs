//Description: This class is used when the player wants to equip a trinket 
//Type: Controller 

using UnityEngine;

public class TwoSlotChoice {

    private EquipmentManager equipmentManager;
    private BarracksManager barracksManager;
    private Color highlightColor;
    private Item twoChoiceItem;
    private ItemType itemTypeInQuestion;

    private InventorySlot slotOne;
    private InventorySlot slotTwo;

    private TwoSlotChoice() { }
    public TwoSlotChoice(EquipmentManager equipmentManager, Item item)
    {
        Debug.Log("TwoSlotChoice RUNNING | TwoSlotChoice RUNNING | TwoSlotChoice RUNNING | TwoSlotChoice RUNNING | ");
        this.equipmentManager = equipmentManager;
        barracksManager = equipmentManager._BarracksManager;
        twoChoiceItem = item;
        itemTypeInQuestion = item.itemType;
        equipmentManager.TwoSlotChoiceInstance = this;
        equipmentManager._BarracksManager.WaitForSlotPicked = true;
       

        if (itemTypeInQuestion == ItemType.Trinket)
        {
            slotOne = equipmentManager.EquipmentSlots[3].GetComponent<InventorySlot>();
            slotTwo = equipmentManager.EquipmentSlots[4].GetComponent<InventorySlot>();
        }
        else
        {
            slotOne = equipmentManager.EquipmentSlots[1].GetComponent<InventorySlot>();
            slotTwo = equipmentManager.EquipmentSlots[2].GetComponent<InventorySlot>();
        }
        Highligt(true);
        
    }
    public void Highligt(bool light)
    {
        Debug.Log("Highlighting");
        slotOne.HightlightSelf(light);
        slotTwo.HightlightSelf(light);
    }
   
    public ItemType ItemTypeInQuestion { get { return itemTypeInQuestion; } }
    public Item TwoChoiceItem { get { return twoChoiceItem; } }
}
