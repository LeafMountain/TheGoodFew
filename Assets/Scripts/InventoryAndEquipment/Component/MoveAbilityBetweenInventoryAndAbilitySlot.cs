using UnityEngine;

public class MoveAbilityBetweenInventoryAndAbilitySlot {

    private MoveAbilityBetweenInventoryAndAbilitySlot() { }
    public MoveAbilityBetweenInventoryAndAbilitySlot(
        AbilityDataOffensive ability, Inventory from, GameObject to)
    {
        from.UnlockedAbilities.Remove(ability);
        to.GetComponent<InventorySlot>().AddAbility(ability);    
    }
    public MoveAbilityBetweenInventoryAndAbilitySlot(
        AbilityDataOffensive ability, GameObject from, Inventory to)
    {
        from.GetComponent<InventorySlot>().ClearSlot();
        to.UnlockedAbilities.Add(ability);
    }

}
