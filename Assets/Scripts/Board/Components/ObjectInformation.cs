using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInformation : MonoBehaviour {
    public string unitName;
    public UnitData UnitData { get { return unitData; } }

    public List<Ability> Abilities { get; private set; }

    [SerializeField]
    private UnitData unitData;

    private void Awake () {
        //If no unitdata exists, use the generic profile
        if (unitData == null) {
            unitData = Resources.Load ("UnitData/Generic") as UnitData;
        }

        //Get the abilities defined in the UnitData
        Abilities = unitData.CreateAbilities ();
    }

    private void Start () {
        //Setup Unit
        if (unitData != null) {
            if (unitName == null || unitName == "") {
                unitName = unitData.title;
            }
        }
    }

    //Subscribers is stored here
    public event EventHandler<UnitUpdate> UnitUpdated;

    protected virtual void OnUnitUpdated () {
        if (UnitUpdated != null)
            UnitUpdated (this, new UnitUpdate (this));
    }
}

public class UnitUpdate : EventArgs {

    public ObjectInformation Unit { get; private set; }
    public int health { get { return Unit.GetComponent<Health>().CurrentHealth; } }

    public UnitUpdate (ObjectInformation unit) {
        this.Unit = unit;
    }
}