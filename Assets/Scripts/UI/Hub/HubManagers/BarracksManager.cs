using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarracksManager : MonoBehaviour {

    private GameObject iconFrame;
    private GameObject inventoryDisplay;
    private InventoryUI inventoryUI;

    public Inventory playerInventory;
    public Sprite[] characterIcon; //< Might be changed to 3D models instead.

    void OnEnable()
    {
        iconFrame = transform.Find("SubMenus").Find("IconFrame").gameObject;
        inventoryDisplay = transform.Find("SubMenus").Find("Inventory Display").gameObject;

        inventoryUI = GetComponentInParent<InventoryUI>();
        inventoryUI.Inventory = playerInventory;
        inventoryUI.inventoryUI = inventoryDisplay.transform.GetChild(0).gameObject;
        inventoryUI.UpdateUI();
    }

    public void OpenCharacter(int characterIndex)
    {
        new OpenCharacter(this, characterIndex);
    }
    
    //Properties
    public GameObject IconFrame { get { return iconFrame; } set { iconFrame = value; } }
    public GameObject InventoryDisplay { get { return inventoryDisplay; } }
    public InventoryUI _InventoryUI { get { return inventoryUI; } set { inventoryUI = value; } }
}
