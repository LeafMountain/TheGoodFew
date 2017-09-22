//Author: Axel Stenkrona
//Description: The item archtype class. 

using UnityEngine;
using System.Collections;
using System.Collections.Generic;


[CreateAssetMenuAttribute(fileName = "New Weapon",menuName = "Item/Equipment/Weapon")]
[System.Serializable]
public class WeaponObject : Item
{
    
    
    public GameObject model;

    public UnitData.Class characterClass;
    public Ability ability;

    //Physical Attack
    public int minimumAtk = 0;
    public int maximumAtk = 1;

    //Magical Attack
    public int minimumPow = 0;
    public int maximumPow = 1;

   
}
