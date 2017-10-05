//Description: This class is put on buttons in a hub menu. 

using UnityEngine;
using UnityEngine.UI;

public class SubHubButtons : MonoBehaviour {

    public GameObject shop;
    public GameObject textbox;
    public GameObject playerInventory;
    public GameObject main;

    public InventoryUI storeUI;
    public InventoryUI playerUI; //<---Need a better name.

    public string[] dialougeLines;
    private int dialougeIndex = 0;

   
    
    public void ReturnToOverView()
    {
        transform.GetComponentInParent<SubMenuTemplate>().gameObject.SetActive(false);
    }
    public void ToggleShop()
    {
        shop.SetActive(!shop.activeSelf);
        main.SetActive(!main.activeSelf);
        storeUI.UpdateUI();
    }
    public void TogglePlayerInventory()
    {
        playerInventory.SetActive(!playerInventory.activeSelf);
        main.SetActive(!main.activeSelf);
        playerUI.UpdateUI();

    }
    public void ToggleDialouge()
    {
        NextDialougeLine();
        textbox.SetActive(!textbox.activeSelf);
        main.SetActive(!main.activeSelf);
    }
    public void ContinueDiaOrBack()
    {
        if (dialougeIndex == dialougeLines.Length - 1)
        {
            ToggleDialouge();
            dialougeIndex = 0;
        }
        else
        {
            dialougeIndex++;
            NextDialougeLine();
            
        }
    }
    private void NextDialougeLine()
    {
        textbox.GetComponentInChildren<Text>().text = dialougeLines[dialougeIndex];
    }

    //properties
    public IHubStates OverViewState { get; set; }
	
}
