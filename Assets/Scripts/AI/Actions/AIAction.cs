﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIAction : ScriptableObject {

	// public AIState actions;

	public abstract bool Execute();
	
}
