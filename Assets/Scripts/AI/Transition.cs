using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.SerializableAttribute]
public class Transition {

	[SerializeField]
	public AIState nextState;
	public AIAction action;
}
