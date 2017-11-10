﻿using UnityEngine;

public class RearrangeAbilitiesOrItems {

    private EquipmentManager equipmentManager;
    private GameObject go;
    private InventorySlot inventorySlot;
    private InventorySlotType type;
    private bool movingAbility;
    private bool clickedInventorySlot;
    private bool playerPickingAbilitySlot;
    
    public RearrangeAbilitiesOrItems(
        EquipmentManager equipmentManager, GameObject go)
    {
        Debug.Log("RUNNING RearrengeAbilitiesOrItems.cs");
        this.equipmentManager = equipmentManager;
        this.go = go;
        inventorySlot = go.GetComponent<InventorySlot>();
        type = inventorySlot.
            SlotType;
        if (inventorySlot._Item == null)
        { movingAbility = true; }

        if ((int)type == 2)
        { clickedInventorySlot = true;}

        playerPickingAbilitySlot =
            equipmentManager._BarracksManager.
            WaitForSlotPicked;

            if (movingAbility) { MoveAbility(); }
        else { MoveEquipment(); }
    }
    private void MoveAbility()
    {
        Debug.Log("RearrengeAbilitiesOrItems.MoveAbility()");
        if(!clickedInventorySlot)
        {
            new UnequipAbility(
                go, equipmentManager.
                _BarracksManager.AbilityInQuestion,
                equipmentManager);
        }
        else
        {
            new EquipAbility(
                equipmentManager._BarracksManager.AbilityInQuestion,
                go, equipmentManager, go.transform.GetSiblingIndex());
        }
    }
    private void MoveEquipment()
    {
        if(!clickedInventorySlot)
        {
            new UnequipItem(go,
                equipmentManager._BarracksManager.ItemInQuestion,
                equipmentManager);
        }
        else
        {
            if(clickedInventorySlot && equipmentManager.
                _BarracksManager.DisplayingEquipment)
            {
                new SwapEquipment(equipmentManager);
                new EquipItem(
                    equipmentManager._BarracksManager.ItemInQuestion,
                    go, equipmentManager);
            }
        }
    }



}
