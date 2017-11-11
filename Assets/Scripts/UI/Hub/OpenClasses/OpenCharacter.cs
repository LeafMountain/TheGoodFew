//Type: Controller
using UnityEngine.UI;

public class OpenCharacter {

    private BarracksManager barracksManager;
    private EquipmentManager equipmentManager;
    private PlayerData playerData;
    private int characterIndex;

    private OpenCharacter() { }
    public OpenCharacter(BarracksManager barracksManager, int characterIndex)
    {
        this.barracksManager = barracksManager;
        this.characterIndex= characterIndex;
        equipmentManager = barracksManager._EquipmentManager;
        playerData = barracksManager.playerData;
      
            //Player inventory prep
        barracksManager.gameObject.transform.Find("SubMenus").
            Find("IconFrame").gameObject.SetActive(true);
        barracksManager.IconFrame.GetComponent<Image>().sprite = 
            barracksManager.characterIcon[characterIndex];

        barracksManager.InventoryDisplay.SetActive(true);
        barracksManager._InventoryUI.UpdateUI();

        //Player equipment prep
        equipmentManager.CurrentEquipment = 
            barracksManager.playerData.CharacterEquipmentList[characterIndex];
        equipmentManager.CurrentAbilities =
            barracksManager.playerData.CharacterAbilitiesList[characterIndex];
        UpdateEquipmentUI();

        //Player experience prep

        new DisplayExperienceStats(
            barracksManager.playerInformation, 
            playerData.ExpManager.AllCharactersExp[characterIndex],
            playerData.ExpManager.AllCharactersLevel[characterIndex]);
        new DisplayAPStats(
            barracksManager.playerInformation,
            playerData.ApManager.AllCharactersAP[characterIndex],
            playerData.ApManager.CurrentlyUnlocking[characterIndex]);
    }

    private void UpdateEquipmentUI()
    {
        equipmentManager.UpdateEqpmtUI();
    }
}
    