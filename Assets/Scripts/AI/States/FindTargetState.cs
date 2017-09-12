using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenuAttribute(menuName = "AI/States/FindTarget")]
public class FindTargetState : AIState {

	public override void StateUpdate(AIController controller){
		DoActions(controller);
	}
}
