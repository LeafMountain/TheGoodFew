using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenCharacter {

    private BarracksManager barracksManager;
    private EquipmentManager equipmentManager;
    private int characterIndex;

    private OpenCharacter() { }
    public OpenCharacter(BarracksManager barracksManager, int characterIndex)
    {
        this.barracksManager = barracksManager;
        this.characterIndex= characterIndex;
        equipmentManager = barracksManager._EquipmentManager;

      
        //Player equipment prep
        

        

        //Player inventory prep
        barracksManager.gameObject.transform.Find("SubMenus").Find("IconFrame").gameObject.SetActive(true);
        barracksManager.IconFrame.GetComponent<Image>().sprite = barracksManager.characterIcon[characterIndex];
        barracksManager.InventoryDisplay.SetActive(true);
        barracksManager._InventoryUI.UpdateUI();

        equipmentManager._Equipment = barracksManager.playerData.characterEquipment[characterIndex];

        foreach (Item item in barracksManager.playerData.characterEquipment[characterIndex].allPieces)
        {
            Debug.Log(item.name);
        }
        UpdateEquipmentUI();
    }

    private void UpdateEquipmentUI()
    {
            GameObject[] equipmentSlots = equipmentManager.EquipmentSlots;
            Equipment characterEquipment = equipmentManager._Equipment;
        for (int i = 0; i < equipmentSlots.Length; i++)
        {
            Debug.Log("Add item in to equipment slot...");

            equipmentSlots[i].GetComponent<InventorySlot>().AddItem(characterEquipment.allPieces[i]);
           
        }    
        
    }
}
    