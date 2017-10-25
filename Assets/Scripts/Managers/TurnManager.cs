using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour {
    public static TurnManager turnManager;

    public List<TurnOrderObject> turnOrder { get; private set; }
    public TurnOrderObject CurrentUnit { get { return turnOrder[0]; } }
    public int enemiesLeft { get; private set; }
    public int heroesLeft { get; private set; }

    public void Awake () {
        turnManager = this;

        turnOrder = new List<TurnOrderObject> ();
    }

    public static TurnManager GetInstance () {
        return turnManager;
    }

    //Subscribers is stored here
    public event EventHandler<TurnOrderUpdate> TurnOrderUpdated;

    protected virtual void OnTurnOrderUpdated () {
        if (TurnOrderUpdated != null)
            TurnOrderUpdated (this, new TurnOrderUpdate (turnOrder));
    }

    public void OnUnitUpdated (object source, UnitUpdate unitUpdate) {
        if ((ObjectInformation) source == CurrentUnit) {
            OnTurnOrderUpdated ();
        }
        if (unitUpdate.health <= 0) {
            RemoveUnit ((TurnOrderObject) source);
        }
    }

    //Manual update from other scripts of the OnUnitUpdated delegate
    public void UpdateTurnOrder () {
        OnTurnOrderUpdated ();
    }

    //Add unit to the last position in the turnOrder list. Removes the unit if it exists in the list.
    public void AddUnit (TurnOrderObject turnOrderObject) {
        if (turnOrder.Contains (turnOrderObject)) {
            RemoveUnit (turnOrderObject);
        }
        // else
        // {
        //     turnOrderObject.Dead += OnDead;
        // }

        // else {
        //     turnOrderObject.UnitUpdated += OnUnitUpdated;
        // }

        turnOrder.Add (turnOrderObject);

        if (turnOrderObject.allegiance == TurnOrderObject.Allegiance.Enemy)
            enemiesLeft++;
        else if (turnOrderObject.allegiance == TurnOrderObject.Allegiance.Friendly)
            heroesLeft++;

        OnTurnOrderUpdated ();
    }

    //Removes a unit from the turnOrder list and changes the unit count.
    public void RemoveUnit (TurnOrderObject turnOrderObject) {
        turnOrder.Remove (turnOrderObject);
        OnTurnOrderUpdated ();

        if (turnOrderObject.allegiance == TurnOrderObject.Allegiance.Enemy)
            enemiesLeft--;
        else if (turnOrderObject.allegiance == TurnOrderObject.Allegiance.Friendly)
            heroesLeft--;
    }

    private void OnDead (object source, EventArgs args) {
        RemoveUnit ((TurnOrderObject) source);
    }

    //Sort units depending on the units speed. High speed goes first
    public void SortUnits () {
        for (int i = 0; i < turnOrder.Count; i++) {
            if (i + 1 < turnOrder.Count) {
                if (turnOrder[i].GetComponent<ObjectInformation> ().UnitData.Speed < turnOrder[i + 1].GetComponent<ObjectInformation> ().UnitData.Speed) {
                    TurnOrderObject holder = turnOrder[i];
                    turnOrder[i] = turnOrder[i + 1];
                    turnOrder[i + 1] = holder;
                    i = 0;
                }
            }
        }

        OnTurnOrderUpdated ();
    }

    public void FindTurnOrderObjects () {
        foreach (TurnOrderObject gridObject in GameObject.FindObjectsOfType (typeof (TurnOrderObject))) {
            turnManager.AddUnit (gridObject);

            // unit.GetComponent<Unit> ().Move (BattleManager.GetInstance().board.GetTile (battleManager.board.ConvertToBoardPosition (unit.transform.position)));
        }

        //Sort units to be in the correct order
        SortUnits ();
    }
}

public class TurnOrderUpdate : EventArgs {
    public TurnOrderObject currentUnit { get { return TurnOrder[0]; } }
    public List<TurnOrderObject> TurnOrder { get; private set; }

    public TurnOrderUpdate (List<TurnOrderObject> newTurnOrder) {
        this.TurnOrder = newTurnOrder;
    }
}