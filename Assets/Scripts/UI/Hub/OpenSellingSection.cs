using UnityEngine;

public class OpenSellingSection : MonoBehaviour {

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
