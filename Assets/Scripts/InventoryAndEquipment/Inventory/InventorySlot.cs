//Description:
using UnityEngine;
using UnityEngine.UI;

/* Sits on all InventorySlots. */
public class InventorySlot : MonoBehaviour
{
    public Image icon;

    private Image frame;
    private ShopManager shopManager;
    private BarracksManager barracksManager;
    
    private Item item;  // Current item in the slot
    private AbilityDataOffensive ability;
    private bool isAbilitySlot;

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
      
        frame = GetComponent<Image>();
        if (gameObject.name[0] == 'A') {
            isAbilitySlot = true; }
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
    public void AddAbility(AbilityDataOffensive newAbility)
    {
        if(newAbility != null)
        {
            Debug.Log("Adding new ability to inventory slot.");
            ability = newAbility;
            icon.sprite = newAbility.icon;
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
    public void SlotClicked()
    {
        Debug.Log("Clicked " + gameObject.name);
        // Checking if this inventory slot is in a shop 
        //sub menu or a in the barracks sub menu.
        new Clicked(this);
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
        new HighlightInventorySlot(this, lit);
    }
    //Properties
    public Item _Item { get { return item; } set { item = value; } }
    public AbilityDataOffensive Ability {
        get { return ability; }
        set { ability = value; } }
    public bool IsAbilitySlot { get { return isAbilitySlot; } }
    public ShopManager _ShopManager { get { return shopManager; } }
    public BarracksManager _BarracksManager { get { return barracksManager; } }
}