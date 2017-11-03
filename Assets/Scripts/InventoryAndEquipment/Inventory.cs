using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    #region Singleton

    public static Inventory instance;
     

    void Awake()
    {
        Debug.Log("Inventory awakes");
        instance = this;
    }

    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public int space = 10;  // Amount of item spaces

    // Our current list of items in the inventory
    public List<Item> items = new List<Item>();

    private List<AbilityDataOffensive> unlockedAbilities = 
        new List<AbilityDataOffensive>();

    // Add a new item if enough room
    public void Add(Item item)
    {
        
            if (items.Count >= space)
            {
                Debug.Log("Not enough room.");
                return;
            }

            items.Add(item);

            if (onItemChangedCallback != null)
                onItemChangedCallback.Invoke();
        
    }

    // Remove an item
    public void Remove(Item item)
    {
        items.Remove(item);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }
    public List<AbilityDataOffensive> UnlockedAbilities{
        get { return unlockedAbilities; }
        set { unlockedAbilities = value; } }

}