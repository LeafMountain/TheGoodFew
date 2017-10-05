using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayItemInformation : MonoBehaviour {

    private Text itemName;
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
        atkForce = transform.GetChild(3).GetComponent<Text>();
        spellPower = transform.GetChild(3).GetComponent<Text>();
         
    }
    public void RecieveInformation(Item item)
    {
        itemName.text = "Title: " + item.itemName;
        itemCost.text = "Costs " + item.price.ToString() + " Epas";
        description.text = item.description;
    }
    public void EmptyDisplay()
    {
        itemName.text = itemCost.text = description.text = "";
    }
}
