﻿//Author: Axel Stenkrona
//Description: This class is put on the return button in a hub menu. 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubReturnButton : MonoBehaviour {

    private IHubStates overViewstate;

    //Called when clicked on the return button in a town menu. The hub state changes to <OverViewState>
    public void ReturnToOverView()
    {

    }

    //properties
    public IHubStates OverViewState { get; set; }
	
}
