//Description: This class is used when the player wants to equip a trinket 
//Type: Controller 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoSlotChoice {

    private EquipmentManager equipmentManager;
    private BarracksManager barracksManager;
    private Color highlightColor;

    private TwoSlotChoice() { }
    public TwoSlotChoice(EquipmentManager equipmentManager)
    {
        this.equipmentManager = equipmentManager;
        barracksManager = equipmentManager._BarracksManager;
        highlightColor = Color.yellow;
    }
    private void Highligt()
    {

    }
    


}
