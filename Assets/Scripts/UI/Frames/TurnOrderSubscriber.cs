using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//For easier subsciption to the turn oreder other classes can use this as super class
public abstract class TurnOrderSubscriber : MonoBehaviour {

    protected BattleManager battleManager;
    public ObjectInformation currentUnit { get; private set; }
    protected TurnManager turnManager;

    public virtual void Start () {
        battleManager = BattleManager.GetInstance();
        turnManager = TurnManager.GetInstance();

        turnManager.TurnOrderUpdated += OnTurnOrderUpdated;
    }

    private void OnTurnOrderUpdated (object source, TurnOrderUpdate turnOrderUpdate) {
        if (currentUnit != null)
            currentUnit.UnitUpdated -= OnUnitUpdated;

        currentUnit = turnOrderUpdate.currentUnit.GetComponent<ObjectInformation>();
        currentUnit.UnitUpdated += OnUnitUpdated;
        UpdateSubscriber();
    }

    private void OnUnitUpdated (object source, UnitUpdate unitUpdate) {
        UpdateSubscriber();
    }

    public abstract void UpdateSubscriber ();
}
