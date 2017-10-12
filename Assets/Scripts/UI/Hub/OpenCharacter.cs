using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenCharacter {

    private BarracksManager barracksManager;
    private int characterIndex;

    private OpenCharacter() { }
    public OpenCharacter(BarracksManager barracksManager, int characterIndex)
    {
        this.barracksManager = barracksManager;
        this.characterIndex= characterIndex;
        barracksManager.gameObject.transform.Find("SubMenus").Find("IconFrame").gameObject.SetActive(true);
        barracksManager.IconFrame.GetComponent<Image>().sprite = barracksManager.characterIcon[characterIndex];
        barracksManager.InventoryDisplay.SetActive(true);
    }
}
