using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EquipmentPart { Head, Body, LeftHand, RightHand, FirstTrinket, SecondTrinket}

public class EquipmentManager {

    private BarracksManager barracksManager;

    private GameObject[] equipmentSlots;
    private Item[] equipment;

    private EquipmentManager() { }
    public EquipmentManager(BarracksManager barracksManager)
    {
        this.barracksManager = barracksManager;
        equipment = new Item[6];
    }
    public void RemoveEquipment(EquipmentPart part)
    {
        equipment[(int)part] = null;
    }
    public void AddEquipment(Item item)
    {
        
    }
}
