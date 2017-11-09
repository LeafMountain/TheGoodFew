using UnityEngine;

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
        this.equipmentManager = equipmentManager;
        this.go = go;
        inventorySlot = go.GetComponent<InventorySlot>();
        type = inventorySlot.
            SlotType;
        if (inventorySlot._Item != null)
        { movingAbility = false; }

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
        if(!clickedInventorySlot)
        {
            new UnequipAbility(
                go, equipmentManager.
                _BarracksManager.AbilityInQuestion,
                equipmentManager);
        }
        else
        {
            
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
