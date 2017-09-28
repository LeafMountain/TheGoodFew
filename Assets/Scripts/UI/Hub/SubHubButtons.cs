//Description: This class is put on buttons in a hub menu. 

using UnityEngine;

public class SubHubButtons : MonoBehaviour {

    public GameObject shop;
    public GameObject textbox;

    //Called when clicked on the return button in a town menu. The hub state changes to <OverViewState>
    public void ReturnToOverView()
    {
        transform.GetComponentInParent<SubMenuTemplate>().gameObject.SetActive(false);
    }
    public void ToggleShop()
    {
        shop.SetActive(!shop.activeSelf);
        textbox.SetActive(!textbox.activeSelf);
        
    }

    //properties
    public IHubStates OverViewState { get; set; }
	
}
