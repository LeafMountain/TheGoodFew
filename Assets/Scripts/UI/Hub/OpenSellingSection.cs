//Note: this could be merged with <OpenBuySection>.
using UnityEngine;

public class OpenSellingSection  {

    private Inventory inventory;
    private ShopManager shopManager;

    private GameObject inventoryDisplay;
    private GameObject main;
    private InventoryUI storeUI;

    private OpenSellingSection() { }
    public OpenSellingSection(Inventory inventory, ShopManager shopManager)
    {
        this.inventory = inventory;
        this.shopManager = shopManager;
        inventoryDisplay = shopManager.inventoryDisplay;
        main = shopManager.main;
        storeUI = shopManager.storeUI;
        shopManager.inventoryTitle.text = "Player Inventory";
        shopManager.Buying = false;
        shopManager.dispayPlayerCoins.text = shopManager._PlayerData.Epas.ToString();
        Open();

    }
    private void Open()
    {
        shopManager.Buying = false;
        storeUI.Inventory = shopManager.playerDataGameObject.GetComponent<Inventory>();
        inventoryDisplay.SetActive(true);
        main.SetActive(!main.activeSelf);
        storeUI.UpdateUI();
    }

}
