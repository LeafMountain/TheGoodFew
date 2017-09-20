using Assets.Code.States.QuestHub;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectSubHubMenu : MonoBehaviour {

    private HubStateMachine hubStateMachine_ref;
    
    public void EnterSubMenu()
    {
        
    }
	
    //properties
       public HubStateMachine HubStateMachine_Ref { get { return hubStateMachine_ref; } set { hubStateMachine_ref = value; } }
	
}
