//Description: Manages movmemt between equipmentSlots and player
//inventory.

using UnityEngine;

public enum EquipmentPart {
    Body, OffHand, MainHand, FirstTrinket, SecondTrinket}
public enum InventorySlotType { 
AbilitySlot, EquipmentSlot, InventorySlot}

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
        abilitySlots = new GameObject[5];
        for (int i = 0; i < playerEquipment.transform.childCount; i++)
        {
            equipmentSlots[i] = 
                playerEquipment.transform.GetChild(i).gameObject;
        }
    } 
    public void SlotClicked(GameObject go) //<<you work here!!
    {
        bool clickedEquipmentSlot = false;
        bool clickedAbilitySlot = false;
        
        for (int i = 0; i < equipmentSlots.Length; i++)
        {
            if(equipmentSlots[i] == go){ clickedEquipmentSlot = true; }
        }
       for (int i = 0; i < abilitySlots.Length; i++)
        {
              if(abilitySlots[i] == go) { clickedAbilitySlot = true; }
        }

        if (clickedEquipmentSlot)
        {
            new UnequipItem(go, barracksManager.ItemInQuestion, this);
        }
        else
        {
            if (!clickedAbilitySlot && _BarracksManager.DisplayingEquipment)
            {
                new SwapEquipment(this);
                new EquipItem(barracksManager.ItemInQuestion, go, this);

            }
            else
            {
                if(clickedAbilitySlot)
                {

                }
                else
                {
                    new EquiipAbility(
                        _BarracksManager.AbilityInQuestion, go, 
                        this, go.transform.GetSiblingIndex());
                }
            }
        }
    }

    public void UpdateEqpmtUI()
    {
        new UpdateBarracksUI(this);
    }
    public void EquipmentSlotPicked(int slot)
    {
        new EquipmentSlotPicked(this, slot);
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
