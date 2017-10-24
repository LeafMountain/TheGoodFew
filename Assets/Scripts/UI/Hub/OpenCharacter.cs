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
            GameObject[] equipmentSlots = equipmentManager.EquipmentSlots;
            Equipment characterEquipment = equipmentManager.CurrentEquipment;

        if (characterEquipment != null)
        {
            for (int i = 0; i < equipmentSlots.Length; i++)
            {
                Debug.Log("Add item in to equipment slot...");

                if (characterEquipment.EquipmentPieces[i] != null)
                {
                    equipmentSlots[i].GetComponent<InventorySlot>().AddItem(characterEquipment.EquipmentPieces[i]);
                }

            }
        }
        else{Debug.Log("Equipment missing for charachter " + (UnitData.Class)characterIndex);}
    }
}
    