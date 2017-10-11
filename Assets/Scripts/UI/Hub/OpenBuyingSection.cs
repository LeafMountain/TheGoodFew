using UnityEngine;

public class OpenBuyingSection {

    private Inventory inventory;
    private ShopManager shopManager;

    private GameObject inventoryDisplay;
    private GameObject main;
    private InventoryUI storeUI;

    private OpenBuyingSection() { }
    public OpenBuyingSection(Inventory inventory, ShopManager shopManager)
    {

        this.inventory = inventory;
        this.shopManager = shopManager;
        inventoryDisplay = shopManager.inventoryDisplay;
        main = shopManager.main;
        storeUI = shopManager.storeUI;
        shopManager.inventoryTitle.text = "Shop Inventory";
        shopManager.Buying = true;
        shopManager.dispayPlayerCoins.text = shopManager._PlayerData.Epas.ToString();
        Open();
    }

    public void Open()
    {
        storeUI.Inventory = inventory;
        inventoryDisplay.SetActive(!inventoryDisplay.activeSelf);
        main.SetActive(!main.activeSelf);
        storeUI.UpdateUI();
        shopManager.Buying = true;
    }
}
