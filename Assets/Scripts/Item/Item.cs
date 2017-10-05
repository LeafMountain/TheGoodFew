//Author: Axel Stenkrona
//Description: the base item class, all items should derive from this.
using UnityEngine;

public class Item : ScriptableObject {

    public string itemName;
    public int price;
    public int worthSecondHand;

    public Sprite icon;
    public string description;

    public string developerNote;

    public bool showInInventory;
    public void Use()
    {
        Debug.Log(itemName + " was used!");
    }
    public void RemoveFromInventory()
    {
        Inventory.instance.Remove(this);
    }
}
