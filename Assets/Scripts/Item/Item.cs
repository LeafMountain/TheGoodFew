//Author: Axel Stenkrona
//Description: the base item class, all items should derive from this.
using UnityEngine;

public class Item : ScriptableObject {

    public string itemName;

    public Sprite icon;
    public string description;

    
    public string developerNote;

    public bool showInInventory;
    public void Use()
    {

    }
    public void RemoveFromInventory()
    {
        Inventory.instance.Remove(this);
    }
}
