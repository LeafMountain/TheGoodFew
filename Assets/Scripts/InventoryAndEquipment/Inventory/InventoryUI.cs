using System.Collections.Generic;
using UnityEngine;

/* This object manages the inventory UI. */

public class InventoryUI : MonoBehaviour
{

    public GameObject inventoryUI;  // The entire UI
    public Transform itemsParent;   // The parent object of all the items

    Inventory inventory;    // Our current inventory

    private List<AbilityDataOffensive> abilities;
    private bool displayingEquipment;

    void Start()
    {
        inventory = GetComponentInChildren<Inventory>();
        displayingEquipment = true;
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

        if (displayingEquipment)
        {
            for (int i = 0; i < slots.Length; i++)
            {
                if (i < inventory.items.Count)
                {
                    slots[i].AddItem(inventory.items[i]);
                }
                else
                {
                    if (slots[i].gameObject.name[0] == 'I') slots[i].ClearSlot();
                }

            }
        }
    }
    public void ClearAllSlots()
    {
        InventorySlot[] slots = GetComponentsInChildren<InventorySlot>();
        foreach(InventorySlot s in slots)
        {
            if(s.gameObject.name[0] == 'I')
            s.ClearSlot();
        }
    }
    public void UpdateUIAbilities()
    {
        Debug.Log("Updateing Inventory UI to Abilities.");
        InventorySlot[] slots = GetComponentsInChildren<InventorySlot>();


        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.UnlockedAbilities.Count)
            {
                slots[i].AddAbility(inventory.UnlockedAbilities[i]);
            }
            else
            {
                if (slots[i].gameObject.name[0] == 'I') slots[i].ClearSlot();
            }

        }
    }
    
    //Properties
    public Inventory Inventory { get { return inventory; } 
        set { inventory = value; } }
    public bool DisplayingEquipment { set { displayingEquipment = value; } }
    public List<AbilityDataOffensive> Abilities { set { abilities = value; } }
}