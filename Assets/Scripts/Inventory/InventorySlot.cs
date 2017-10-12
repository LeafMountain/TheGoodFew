//Description:
using UnityEngine;
using UnityEngine.UI;

/* Sits on all InventorySlots. */

public class InventorySlot : MonoBehaviour
{

    public Image icon;
    

    private ShopManager shopManager;
    private BarracksManager barracksManager;

    Item item;  // Current item in the slot

    void Start()
    {
        shopManager = GetComponentInParent<ShopManager>();
        barracksManager = GetComponentInParent<BarracksManager>();
    }

    // Add item to the slot
    public void AddItem(Item newItem)
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
       
    }

    // Clear the slot
    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
       
    }

    // If the remove button is pressed, this function will be called.
    public void RemoveItemFromInventory()
    {
        Inventory.instance.Remove(item);
    }

    // Use the item
    public void UseItem()
    {
       if (item != null)
       {
            item.Use();
       }
    }
    public void InventorySlotClicked()
    {
        if (shopManager != null)
        {
            shopManager.ItemInQuestion = item;
            shopManager.Ask(item.itemName, item.price);
        }
        else
        {
            barracksManager.ItemInQuestion = item;
        }
    }
   
    public void ShowItemInfo()
    {
        if (item != null)
        {
            shopManager.informationDisplay.RecieveInformation(item);
        }
    }
    public void RemoveItemInfo()
    {
        shopManager.informationDisplay.EmptyDisplay();
    }
   
   

}