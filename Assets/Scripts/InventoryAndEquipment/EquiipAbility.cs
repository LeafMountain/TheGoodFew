﻿using System.Collections.Generic;
using UnityEngine;

public class EquiipAbility {

    private AbilityDataOffensive ability;
    private GameObject gameObject;
    private EquipmentManager equipmentManager;
    private GameObject[] abilitySlots;
    private BarracksManager barracksManager;
    private List<AbilityDataOffensive> unlockedAbilities;
    private AbilityPointsData apData;
    private Inventory playerInventory;
    private EquippedAbilities currentAbilities;
    private int abilitySlotIndex;

    public EquiipAbility(
        AbilityDataOffensive ability, GameObject go, 
        EquipmentManager equipmentManager, int abilitySlotIndex)
    {
        this.ability = ability;
        gameObject = go;
        this.equipmentManager = equipmentManager;
        this.abilitySlotIndex = abilitySlotIndex;
        barracksManager = 
            equipmentManager._BarracksManager;
        apData = 
            barracksManager.playerData.APData;
        unlockedAbilities = barracksManager.
            _InventoryUI.Inventory.UnlockedAbilities;
        abilitySlots =
            equipmentManager.AbilitySlots;
        playerInventory =
            barracksManager._InventoryUI.Inventory;
        currentAbilities =
            equipmentManager.CurrentAbilities;

    }

    private void Equip()
    {
        Debug.Log("Equipping " + ability.ToString());
        GameObject slot = abilitySlots[abilitySlotIndex];

        AbilityDataOffensive currentlyEquippedAbility =
            slot.GetComponent<InventorySlot>().Ability;

        if(currentlyEquippedAbility != null)
        {
            new MoveAbilityBetweenInventoryAndAbilitySlot(
                currentlyEquippedAbility, slot, playerInventory);
        }
        else
        {
            new MoveAbilityBetweenInventoryAndAbilitySlot(
                ability, playerInventory, slot);
        }

        currentAbilities.AllAbilities[abilitySlotIndex] = ability;
    }
}