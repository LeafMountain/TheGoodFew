using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOrderFrame : MonoBehaviour {

    private List<PortraitTurnOrder> turnOrderPortraits = new List<PortraitTurnOrder> ();

    // Use this for initialization
    private void Start () {
        AddTurnOrderComponents ();
        TurnManager.GetInstance().TurnOrderUpdated += OnTurnOrderUpdated;
    }

    //Adds PortraitTurnOrder to a list for easy access
    private void AddTurnOrderComponents () {
        foreach (PortraitTurnOrder img in GetComponentsInChildren<PortraitTurnOrder> ()) {
            turnOrderPortraits.Add (img);
        }
    }

    private void OnTurnOrderUpdated (object source, TurnOrderUpdate turnOrderUpdate) {
        UpdateTurnOrder (turnOrderUpdate.TurnOrder);
    }

    //Update turnorder components with the right image and disable unused turn order places
    public void UpdateTurnOrder (List<TurnOrderObject> newTurnOrder) {
        for (int i = 0; i < turnOrderPortraits.Count; i++) {
            if (i < newTurnOrder.Count) {
                turnOrderPortraits[i].gameObject.SetActive (true);
                turnOrderPortraits[i].SetImage (newTurnOrder[i].GetComponent<ObjectInformation> ().UnitData.portrait);
            } else {
                turnOrderPortraits[i].gameObject.SetActive (false);
            }
        }
    }
}