﻿//Description: This class is put on buttons in a hub menu. 

using UnityEngine;
using UnityEngine.UI;

public class SubHubButtons : MonoBehaviour {

    private ShopManager shopManager;
    private BarracksManager barracksManager;

    void Start()
    {
        shopManager = GetComponent<ShopManager>();
    }
    
    public void ReturnToOverView()
    {
        gameObject.SetActive(false);
    }
    public void OpenBuySection()
    {
        shopManager.Buying = true;
        shopManager.OpenShopSection();
    }
    public void OpenSellSection()
    {
        shopManager.Buying = false;
        shopManager.OpenShopSection();
    }
    public void GoBack()
    {
        shopManager.CloseChildren();
    }
    public void DialougeButton()
    {
        shopManager.ClickDialougeButton();
    }
    
    //properties
    public IHubStates OverViewState { get; set; }
	
}
