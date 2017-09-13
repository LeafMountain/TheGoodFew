//Author: Axel Stenkrona
//Description: The item archtype class. 

using UnityEngine;
using System.Collections;
using System.Collections.Generic;


[CreateAssetMenuAttribute(fileName = "New Weapon",menuName = "Item/Consumable")]
[System.Serializable]
public class ConsumabeObject : ScriptableObject
{
    new public string name = "New Consumable";
    public Sprite icon;
    public GameObject model;

    public UnitData.Class characterClass;
    public Ability ability;

    //Cool Lore Text
    public string description;

    //Developer Note
    public string note;


}
