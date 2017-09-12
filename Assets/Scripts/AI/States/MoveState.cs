using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenuAttribute (menuName = "AI/States/Move state")]
public class MoveState : AIState {

    public AIState trueState;

    public override void StateUpdate (AIController controller) {
        DoActions (controller);
    }


}