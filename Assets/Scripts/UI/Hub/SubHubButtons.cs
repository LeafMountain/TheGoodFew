﻿//Description: This class is put on buttons in a hub menu. 

using UnityEngine;
using UnityEngine.UI;

public class SubHubButtons : MonoBehaviour {

    public GameObject shop;
    public GameObject textbox;
    public GameObject playerInventory;
    public GameObject main;

    public InventoryUI storeUI; //entire UI;


    public string[] dialougeLines;
    private int dialougeIndex = 0;

   
    
    public void ReturnToOverView()
    {
        transform.GetComponentInParent<SubMenuTemplate>().gameObject.SetActive(false);
    }
    public void ToggleShop()
    {
        shop.SetActive(!shop.activeSelf);
        main.SetActive(!main.activeSelf);
        storeUI.UpdateUI();
        GetComponentInParent<ShopManager>().Buying = true;
    }
    public void TogglePlayerInventory()
    {
        playerInventory.SetActive(!playerInventory.activeSelf);
        main.SetActive(!main.activeSelf);
        storeUI.UpdateUI();
        GetComponentInParent<ShopManager>().Buying = false; //<<- selling not buying.

    }
    public void ToggleDialouge()
    {
        NextDialougeLine();
        textbox.SetActive(!textbox.activeSelf);
        main.SetActive(!main.activeSelf);
    }
    public void ContinueDiaOrBack()
    {
        if (dialougeIndex == dialougeLines.Length - 1)
        {
            ToggleDialouge();
            dialougeIndex = 0;
        }
        else
        {
            dialougeIndex++;
            NextDialougeLine();
            
        }
    }
    private void NextDialougeLine()
    {
        textbox.GetComponentInChildren<Text>().text = dialougeLines[dialougeIndex];
    }

    //properties
    public IHubStates OverViewState { get; set; }
	
}
