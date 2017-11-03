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
    private Color highligtColor;
    private Color normalColor;
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
        highligtColor = Color.yellow;
        normalColor = Color.white;
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
        // Checking if this inventory slot is in a shop 
        //sub menu or a in the barracks sub menu.
        if (!isAbilitySlot)
        {
            if (item != null)
            {
                if (shopManager != null)
                {
                    new InventorySlotClicked(shopManager, item);
                }
                else
                {
                    if (!barracksManager.WaitForSlotPicked)
                    {
                        new InventorySlotClicked(
                            barracksManager, item, gameObject);
                    }
                    else
                    {
                        barracksManager._EquipmentManager.EquipmentSlotPicked(
                            transform.GetSiblingIndex());
                    }
                }
            }
        }
        else
        {
            if(ability != null)
            {

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
        Image imageComponent =
            transform.GetChild(0).gameObject.GetComponent<Image>();

        if (lit)
        {
           imageComponent.color = highligtColor;   
        }
        else
        {
            imageComponent.color = normalColor;
        }
    }
    //Properties
    public Item _Item { get { return item; } set { item = value; } }
    public AbilityDataOffensive Ability {
        get { return ability; }
        set { ability = value; } }
}