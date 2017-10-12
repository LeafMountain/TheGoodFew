using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EquipmentPart { Body, LeftHand, RightHand, FirstTrinket, SecondTrinket}

public class EquipmentManager {

    private BarracksManager barracksManager;

    private GameObject[] equipmentSlots;
    private Item[] equipment;

    private EquipmentManager() { }
    public EquipmentManager(BarracksManager barracksManager)
    {
        this.barracksManager = barracksManager;
        equipment = new Item[5];
        equipmentSlots = new GameObject[5];
        for (int i = 0; i < barracksManager.playerEquipment.transform.childCount; i++)
        {
            equipmentSlots[i] = barracksManager.playerEquipment.transform.GetChild(i).gameObject;
        }
    }
    public void RemoveEquipment(EquipmentPart part)
    {
        equipment[(int)part] = null;
    }
    public void AddEquipment(Item item)
    {
        
    }
    //Properties
    
}
