using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIState : ScriptableObject {

    // [HeaderAttribute ("Pickers")]
    // public AIAction targetPicker;
    // public AIAction movePicker;
    // public AIAction abilityPicker;

	public List<Transition> transitions = new List<Transition>();

    public abstract void StateUpdate (AIController controller);

    protected void DoActions (AIController controller) {
        for (int i = 0; i < transitions.Count; i++) {
            if (transitions[i].action.Execute ()) {
                controller.ChangeState (transitions[i].nextState);
            }
        }
    }

}