//Discription: When clicking on the different shops this is used to get the right shop to appear.
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectSubHubMenu : MonoBehaviour {

    
    public void OnMouseOver()
    {
        if (EventSystem.current.IsPointerOverGameObject()){ return; }
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
