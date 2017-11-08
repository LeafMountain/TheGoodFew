public class UpdateUI {

    private EquipmentManager equipmentManager;

    public UpdateUI(
        EquipmentManager equipmentManager, bool updateAbilityUI,
        bool updateEquipmentUI, bool updateInventoryUI)
    {
        this.equipmentManager = equipmentManager;
        if (updateAbilityUI) { UpdateAbilityUI(); }
        if (updateEquipmentUI) { UpdateEquipmentUI(); }
        if (updateInventoryUI) { UpdateInventoryUI(); }
    }
    private void UpdateAbilityUI()
    {
        if (equipmentManager.CurrentAbilities != null)
        {
            for (int i = 0; i < equipmentManager.AbilitySlots.Length; i++)
            {
                if (equipmentManager.CurrentAbilities.
                    AllAbilities[i] != null)
                {
                    equipmentManager.
                        AbilitySlots[i].GetComponent<InventorySlot>().

                        AddAbility(
                        equipmentManager.CurrentAbilities.AllAbilities[i]);
                }
            }
        }
    }
    private void UpdateEquipmentUI()
    {
        if (equipmentManager.CurrentEquipment != null)
        {
            for (int i = 0; i < equipmentManager.EquipmentSlots.Length; i++)
            {
                if (equipmentManager.CurrentEquipment.
                    EquipmentPieces[i] != null)
                {
                    equipmentManager.
                        EquipmentSlots[i].GetComponent<InventorySlot>().
                        
                        AddItem(
                        equipmentManager.CurrentEquipment.EquipmentPieces[i]);
                }
            }
        }
    }
    private void UpdateInventoryUI()
    {
        equipmentManager._BarracksManager._InventoryUI.UpdateUI();
    }

}
