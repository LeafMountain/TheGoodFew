using UnityEngine;

/* This object manages the inventory UI. */

public class InventoryUI : MonoBehaviour
{

    public GameObject inventoryUI;  // The entire UI
    public Transform itemsParent;   // The parent object of all the items

    Inventory inventory;    // Our current inventory

    void Start()
    {
        inventory = GetComponentInChildren<Inventory>();

        if(inventory != null) inventory.onItemChangedCallback += UpdateUI;
    }

    // Update the inventory UI by:
    //		- Adding items
    //		- Clearing empty slots
    // This is called using a delegate on the Inventory.
    public void UpdateUI()
    {
        Debug.Log("Updating Inventory UI");
        InventorySlot[] slots = GetComponentsInChildren<InventorySlot>();

        
            for (int i = 0; i < slots.Length; i++)
            {
                if (i < inventory.items.Count)
                {
                    slots[i].AddItem(inventory.items[i]);
                }
                else
                {
                    if(slots[i].gameObject.name[0] == 'I') slots[i].ClearSlot();
                }
            
        }
    }
    //Properties
    public Inventory Inventory { set { inventory = value; } }
}