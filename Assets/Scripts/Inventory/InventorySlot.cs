﻿//Description:
using UnityEngine;
using UnityEngine.UI;

/* Sits on all InventorySlots. */
public class InventorySlot : MonoBehaviour
{
    public Image icon;

    private Image frame;
    private ShopManager shopManager;
    private BarracksManager barracksManager;
    private Color highligtColor;
    private Color normalColor;
    private Item item;  // Current item in the slot

    void Start()
    {
        if (GetComponentInParent<ShopManager>() != null)
        {
            shopManager = GetComponentInParent<ShopManager>();
        }
        else
        {
            barracksManager = GetComponentInParent<BarracksManager>();
        }
        highligtColor = Color.yellow;
        normalColor = Color.white;
        frame = GetComponent<Image>();
    }
    // Add item to the slot
    public void AddItem(Item newItem)
    {
        if (newItem != null)
        {
            item = newItem;
            icon.sprite = item.icon;
            icon.enabled = true;
        }

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
        // Checking if this inventory slot is in a shop sub menu or a in the barracks sub menu.
        if (item != null)
        {
            if (shopManager != null)
            {
                shopManager.ItemInQuestion = item;
                shopManager.Ask(item.itemName, item.price);
            }
            else
            {
                if (!barracksManager.WaitForSlotPicked)
                {
                    barracksManager.ItemInQuestion = item;
                    barracksManager.InventorySlotClicked(gameObject, item);
                }
                else
                {
                    barracksManager._EquipmentManager.EquipmentSlotPicked(transform.GetSiblingIndex());
                }
            }
        }
    }
    public void ShowItemInfo()
    {
        if (item != null)
        {
            if (shopManager != null)
            {
                shopManager.informationDisplay.RecieveInformation(item);
            }
            else
            {
                barracksManager.informationDisplay.RecieveInformation(item);
            }
        }
    }
    public void RemoveItemInfo()
    {
        if(shopManager != null)
        {
            shopManager.informationDisplay.EmptyDisplay();
        }
        else
        {
            barracksManager.informationDisplay.EmptyDisplay();
        }
        
    }
    public void HightlightSelf(bool lit)
    {
        if (lit)
        {
           transform.GetChild(0).gameObject.GetComponent<Image>().color = highligtColor;   
        }
        else
        {
            transform.GetChild(0).gameObject.GetComponent<Image>().color = normalColor;
        }
    }
    //Properties
    public Item _Item { get { return item; } set { item = value; } }
}