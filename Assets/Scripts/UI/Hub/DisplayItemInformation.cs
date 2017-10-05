using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayItemInformation : MonoBehaviour {

    private Text itemName; //<< general info
    private Text itemCost;
    private Text description;

    private Text whatClass;
    private Text specialAbility;

    private Text atkForce; //<< Attack
    private Text spellPower;

    private Text defence; //<< def
    private Text resistance;
    
    
    

    void Start()
    {
        itemName = transform.GetChild(1).GetComponent<Text>();
        itemCost = transform.GetChild(2).GetComponent<Text>();
        description = transform.GetChild(3).GetComponent<Text>();
        whatClass = transform.GetChild(4).GetComponent<Text>();
        specialAbility = transform.GetChild(5).GetComponent<Text>();
        atkForce = transform.GetChild(6).GetComponent<Text>();
        spellPower = transform.GetChild(7).GetComponent<Text>();
        defence = transform.GetChild(8).GetComponent<Text>();
        resistance = transform.GetChild(9).GetComponent<Text>();

    }
    public void RecieveInformation(Item item)
    {
        ItemType whatType = item.itemType;

        itemName.text = "Title: " + item.itemName;
        itemCost.text = "Costs " + item.price.ToString() + " Epas";
        description.text = item.description;

        if(whatType == ItemType.Armor)
        {
            ArmorObject armor = (ArmorObject)item;

            whatClass.text = "Armour Type: " + GetArmorType(armor.armortype);

            defence.text = "Physical Defence: " + armor.physicalDefence.ToString();
            resistance.text = "Resistance: " + armor.magicalDefence.ToString();

        }
        else if(whatType == ItemType.Consumables)
        {
            ConsumableObject consumable = (ConsumableObject)item;
            specialAbility.text = "Poof";
        }
        else if(whatType == ItemType.Weapon)
        {
            WeaponObject weapon = (WeaponObject)item;

            whatClass.text = "Wielded by: " + GetClass(weapon.characterClass).ToString();
            atkForce.text = "Attack Force: " + weapon.minimumAtk + " - " + weapon.maximumAtk; 
        }
    }
    public void EmptyDisplay()
    {
        itemName.text = itemCost.text = description.text = "";
    }
    public string GetClass(UnitData.Class type)
    {
        if ((int)type == 0) return "Soldier";
        else if ((int)type == 1) return "Scout";
        else if ((int)type == 1) return "Archer";
        else if ((int)type == 1) return "Acolyte";
        return "Apprentice";

    }
    public string GetArmorType(ArmorType type)
    {
        if ((int)type == 0) return "Light";
        else if ((int)type == 1) return "Medium";
        else if ((int)type == 1) return "Heavy";
        return "Cloth";
    }


}
