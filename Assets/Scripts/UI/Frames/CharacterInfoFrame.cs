using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterInfoFrame : TurnOrderSubscriber {

    //Information
    public Text primaryClass;

    //Offensive
    public Text atk;
    public Text pow;
    public Text hit;
    public Text mHit;

    //Defensive
    public Text def;
    public Text res;
    public Text block;

    public override void Start () {
        base.Start();
        gameObject.SetActive(false);
    }

    public override void UpdateSubscriber () {
        UpdateDisplay(currentUnit);
    }

    //Updates values on UI
    private void UpdateDisplay (ObjectInformation unit) {
        primaryClass.text = unit.UnitData.primaryClass.ToString();

        atk.text = "Atk: " + unit.UnitData.Atk;
        pow.text = "Pow: " + unit.UnitData.Pow;
        hit.text = "Hit: " + (unit.UnitData.Hit) + "%";
        mHit.text = "MHit: " + (unit.UnitData.MHit) + "%";


        def.text = "Def: " + unit.UnitData.Def;
        res.text = "Res: " + unit.UnitData.Res;
        block.text = "Block: " + (unit.UnitData.Block) + "%";

    }
}