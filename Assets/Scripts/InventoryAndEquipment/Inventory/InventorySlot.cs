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
    private InventorySlotType slotType;

    void Start()
    {
        if (GetComponentInParent<ShopManager>() != null)
        {shopManager = GetComponentInParent<ShopManager>();}
        else
        {barracksManager = GetComponentInParent<BarracksManager>();}
        frame = GetComponent<Image>();
        if (gameObject.name[0] == 'A')
        { slotType =
                InventorySlotType.AbilitySlot;}
        else if (gameObject.name[0] == 'I')
        {slotType =
                InventorySlotType.InventorySlot;}
        else if (gameObject.name[0] != 'A' || gameObject.name[0] != 'I')
        {slotType = InventorySlotType.EquipmentSlot;}
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
        if (item != null) item.Use();
    }
    public void SlotClicked()
    {
        Debug.Log("Clicked " + gameObject.name);
        new Clicked(this);
    }
    public void ShowItemInfo()
    {
        new ItemInfo(this, true);
    }
    public void RemoveItemInfo()
    {
        new ItemInfo(this, false);
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
    public ShopManager _ShopManager { get { return shopManager; } }
    public BarracksManager _BarracksManager { get { return barracksManager; } }
    public InventorySlotType SlotType { get { return slotType; } }
}