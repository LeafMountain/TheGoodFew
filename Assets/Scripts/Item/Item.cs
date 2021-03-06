﻿//Author: Axel Stenkrona
//Description: the base item class, all items should derive from this.
using UnityEngine;

public enum ItemType { Armor, OffHand, Weapon, Trinket, Consumables};

public class Item : ScriptableObject {

    public string itemName;
    public int price;
    public ItemType itemType;

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
