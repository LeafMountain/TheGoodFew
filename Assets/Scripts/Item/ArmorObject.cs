﻿//Author: Axel Stenkrona
//Description: The item archtype class. 

using UnityEngine;
using System.Collections;
using System.Collections.Generic;


[CreateAssetMenuAttribute(fileName = "New Armor", menuName = "Item/Equipment/Armor")]

[System.Serializable]
public class ArmorObject : ScriptableObject
{

    public enum ArmorType {Light, Medium, Sheild, Cloth}

    new public string name = "New Armor";
    public Sprite icon;
    public GameObject model;

    public UnitData.Class characterClass;
    public ArmorType armortype;
    public Ability ability;

    //Physical Defence Stat.
    public int physicalDefence;
    public int magicalDefence;

    public float blockChance;
    public int speedPenalty; 

    //Cool Lore Text
    public string description;

    //Developer Note
    public string note;


}
