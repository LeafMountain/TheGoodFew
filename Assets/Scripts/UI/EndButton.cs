using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndButton : MonoBehaviour {

    private void Start () {
        GetComponent<Button>().onClick.AddListener(() => EndTurnButton());
    }

    //End turn. Add to button listener
    public void EndTurnButton () {
        BattleManager.GetInstance().combatStateMachine.UnitStateMachine.EndTurn();
    }

}
