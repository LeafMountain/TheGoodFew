using UnityEngine;

public class UnequipAbility{

    private EquipmentManager equipmentManager;
    private EquippedAbilities equippedAbilities;
    private GameObject[] abilitySlots;

    public UnequipAbility(GameObject go, 
        AbilityDataOffensive ability, EquipmentManager equipmentManager)
    {
        this.equipmentManager = equipmentManager;
        equippedAbilities = equipmentManager.CurrentAbilities;
        abilitySlots = equipmentManager.AbilitySlots;

        Unequip(go, ability);
    }
    private void Unequip(GameObject go, AbilityDataOffensive ability)
    {
        if(go.GetComponent<InventorySlot>().Ability != null)
        {
            new MoveAbilityBetweenInventoryAndAbilitySlot(
                ability, go, equipmentManager._BarracksManager.
                playerInventory);
            RemoveAbility(go, ability);
        }
        else
        {
            Debug.Log("There is no ability to unequip.");
        }
    }
    private void RemoveAbility(GameObject go, AbilityDataOffensive ability)
    {

    }
}
