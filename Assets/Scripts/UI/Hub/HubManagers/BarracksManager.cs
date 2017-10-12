﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarracksManager : MonoBehaviour {

    private GameObject iconFrame;
    private GameObject inventoryDisplay;

    public Inventory playerInventory;
    public Sprite[] characterIcon; //< Might be changed to 3D models instead.

    void Start()
    {
        iconFrame = transform.Find("SubMenus").Find("IconFrame").gameObject;
        inventoryDisplay = transform.Find("SubMenus").Find("Inventory Display").gameObject;
        GetComponentInParent<InventoryUI>().Inventory = playerInventory; 
    }

    public void OpenCharacter(int characterIndex)
    {
        new OpenCharacter(this, characterIndex);
    }
    
    //Properties
    public GameObject IconFrame { get { return iconFrame; } set { iconFrame = value; } }
    public GameObject InventoryDisplay { get { return inventoryDisplay; } }
}
