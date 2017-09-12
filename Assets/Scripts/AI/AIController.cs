using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour {

	public bool moveUsed;
	public bool actionUsed;

    private bool active;
    public AIState currentState;


    public void Activate () {
        active = true;
    }

    public void Deactivate () {
        active = false;
    }

    public void ChangeState (AIState newState) {
        currentState = newState;
    }

    private void Update () {
        if (!active) {
            return;
        }

        currentState.StateUpdate (this);
    }
}