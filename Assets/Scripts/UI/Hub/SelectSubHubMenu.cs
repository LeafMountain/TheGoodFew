//Author: Axel Stenkrona
//Discription: When clicking on the different shops this is used to get the right shop to appear.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectSubHubMenu : MonoBehaviour {

    
    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0)) { transform.GetComponentInParent<HubManager>().SelectedSubHub(gameObject.name); }
    }

    public void EnterSubMenu()
    {
        
    }
    private void MoveCamera()
    {

    }
	
    //properties
      
	
}
