//Description: Manages movmemt between equipmentSlots and player
//inventory.

using UnityEngine;

public enum EquipmentPart {
    Body, OffHand, MainHand, FirstTrinket, SecondTrinket}

public class EquipmentManager {

    private BarracksManager barracksManager;
    private GameObject[] equipmentSlots;
    private GameObject[] abilitySlots;
    private Equipment currentEquipment;
    private EquippedAbilities currentAbilities;
    private GameObject playerEquipment;
    private Inventory playerInventory;

    private bool canDuelWield; //<< Future ability.
    private UnitData currentCharacter; 
    private TwoSlotChoice twoSlotChoiceInstance; 

    private EquipmentManager() { }//Constructor
    public EquipmentManager(BarracksManager barracksManager)
    {
        this.barracksManager = barracksManager;
        playerEquipment = barracksManager.playerEquipment;
        playerInventory = barracksManager.playerInventory;
        equipmentSlots = new GameObject[5];
        for (int i = 0; i < playerEquipment.transform.childCount; i++)
        {
            equipmentSlots[i] = 
                playerEquipment.transform.GetChild(i).gameObject;
        }
    } 
    public void SlotClicked(GameObject go)
    {
        bool clickedEquipmentSlot = false;
        
        for (int i = 0; i < equipmentSlots.Length; i++)
        {
            if(equipmentSlots[i] == go){ clickedEquipmentSlot = true; }
        }
        if (clickedEquipmentSlot)
        {
            new UnequipItem(go, barracksManager.ItemInQuestion, this);
        }
        else
        {
                new SwapEquipment(this);
                new EquipItem(barracksManager.ItemInQuestion, go, this);
        }
    }
    public void AbilitySlotClicked()
    {

    }
    public void UpdateEqpmtUI()
    {
        new UpdateEquipmentUI(this);
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
                playerInventory.Add(barracksManager.ItemInQuestion);
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
                playerInventory.Add(barracksManager.ItemInQuestion);
                barracksManager.ItemInQuestion = null;
            }
            UpdateEqpmtUI();
            _BarracksManager._InventoryUI.UpdateUI();
        }
    }
    //Properties
    public BarracksManager _BarracksManager {
        get { return barracksManager; } }
    public GameObject[] EquipmentSlots {
        get { return equipmentSlots; } }
    public Equipment CurrentEquipment {
        get { return currentEquipment; }
        set { currentEquipment = value; } }
    public TwoSlotChoice TwoSlotChoiceInstance {
        get { return twoSlotChoiceInstance; }
        set { twoSlotChoiceInstance = value; } }
    public bool CanDuelWield {
        get { return canDuelWield; } }
    public GameObject[] AbilitySlots {
        get { return abilitySlots; } }
    public EquippedAbilities CurrentAbilities {
        get { return currentAbilities; }
        set { currentAbilities = value; } }
}
