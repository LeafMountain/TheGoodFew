//Description: This class is put on buttons in a hub menu. 

using UnityEngine;

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
    public void InventoryToggleButton()
    {
        if (!barracksManager.WaitForSlotPicked)
        {
            barracksManager.ToggleInventory();
        }
    }
    
    //properties
    public IHubStates OverViewState { get; set; }
	
}
