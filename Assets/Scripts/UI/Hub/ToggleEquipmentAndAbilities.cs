using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleEquipmentAndAbilities {

    private BarracksManager barracksmanager;
    private Text buttonText;
    private bool displayingEquipment;
    private int characterIndex;

    public ToggleEquipmentAndAbilities(BarracksManager barracksmanager)
    {
        Debug.Log("ToggleEquipmentAndAbilities");
        this.barracksmanager = barracksmanager;
        buttonText =
            barracksmanager.toggleButton.GetComponentInChildren<Text>();
        displayingEquipment =
            barracksmanager.DisplayingEquipment;
        characterIndex =
            barracksmanager.CharacterIndex; 

        ChangeText();

        if (!displayingEquipment)
        {
            ChangeToAbilities();
        }
        else
        {
            barracksmanager._InventoryUI.UpdateUI();
        }
    }
    private void ChangeText()
    {
        if(displayingEquipment)
        {
            buttonText.text = "Equipment";
        }
        else
        {
            buttonText.text = "Abilities";
        }
        
    }
    private void ChangeToAbilities()
    {
        Debug.Log("Changing the content of the displaying"
            +" inventory, to displaying abilities");
        Inventory inventory = barracksmanager.Inventory;
        int[] unlockedAbilitiesIndex = barracksmanager.playerData.
            ApManager.AllCharactersAbilities[characterIndex].
            abilities;

        List<AbilityDataOffensive> unlockedAbilities =
            new List<AbilityDataOffensive>();


        for (int i = 0; i < unlockedAbilitiesIndex.Length; i++)
        {
            if(unlockedAbilitiesIndex[i] == 1)
            {
                unlockedAbilities.Add(
                    barracksmanager.playerData.Abilities[i]);
            }
        }

        barracksmanager._InventoryUI.Inventory.UnlockedAbilities = unlockedAbilities;
        barracksmanager._InventoryUI.DisplayingEquipment = displayingEquipment;
        barracksmanager._InventoryUI.ClearAllSlots(); 
        
       barracksmanager._InventoryUI.UpdateUIAbilities();

    }
   
}
