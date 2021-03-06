﻿using UnityEngine;
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

      
        
        

        

        //Player inventory prep
        barracksManager.gameObject.transform.Find("SubMenus").Find("IconFrame").gameObject.SetActive(true);
        barracksManager.IconFrame.GetComponent<Image>().sprite = barracksManager.characterIcon[characterIndex];
        barracksManager.InventoryDisplay.SetActive(true);
        barracksManager._InventoryUI.UpdateUI();

        //Player equipment prep
        equipmentManager.CurrentEquipment = barracksManager.playerData.CharacterEquipmentList[characterIndex];
        UpdateEquipmentUI();
    }

    private void UpdateEquipmentUI()
    {
        equipmentManager.UpdateEquipmentUI();
    }
}
    