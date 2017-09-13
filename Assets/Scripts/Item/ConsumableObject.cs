//Author: Axel Stenkrona
//Description: The consumable item archtype class. 

using UnityEngine;
using System.Collections;
using System.Collections.Generic;


[CreateAssetMenuAttribute(fileName = "New ConsumableObject",menuName = "Item/Consumable")]

[System.Serializable]
public class ConsumableObject : ScriptableObject
{
    new public string name = "New Consumable";
    public Sprite icon;
    public GameObject model;

    public Ability ability;

    public int cost;
    public int duration;

    //Cool Lore Text
    public string description;

    //Developer Note
    public string note;


}
