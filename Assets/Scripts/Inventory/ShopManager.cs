using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour {

    private PlayerData playerData;
    public GameObject playerDataGameObject;
    public DisplayItemInformation informationDisplay;
    public InventoryUI storeUI;
    //GameObjects
    public Text inventoryTitle;
    public GameObject confirmPurches;
    public GameObject main;
    public GameObject inventoryDisplay;
    public GameObject textBox;
    public GameObject subMenus;

    public int shopGoldCoins;
    public Text dispayPlayerCoins;

    private bool buying; //<< Is the player in the sell or buy menu. Set when player press buy or sell button.
    private Item itemInQuestion; //<<The item that is being sold or bought. Set when player presses a itemslot.
    private DialougeData dialougeData;
    private Inventory inventory;


	void Start () {
        playerData = playerDataGameObject.GetComponent<PlayerData>();
        dispayPlayerCoins.text = playerData.Epas.ToString();
        dialougeData = GetComponent<DialougeData>();
        inventory = GetComponent<Inventory>();
    }

    //SubMenus
    public void OpenShopSection()
    {
        if(buying)
        {
            new OpenBuyingSection(GetComponent<Inventory>(), this);
        }
        else
        {
            new OpenSellingSection(GetComponent<Inventory>(), this);
        }
    }
    public void OpenDialougeBox()
    {
        new OpenDialouge(this);
    }
    public void ClickDialougeButton()
    {
        dialougeData.ContinueDiaOrBack();
    }
    public void CloseChildren()
    {
        //Not closing the Main child but opening it.

        for (int i = 1; i < subMenus.transform.childCount; i++)
        {
            subMenus.transform.GetChild(i).gameObject.SetActive(false);

        }
        subMenus.transform.GetChild(0).gameObject.SetActive(true);
    }
    private void ExecuteTransaction()
    {
        new Transactions(this);
    }
    public void Answer(string answer)
    {
        if (answer == "Yes")
        {
            if(buying)
            {
                ExecuteTransaction();
                confirmPurches.SetActive(!confirmPurches.activeSelf);
            }
            else
            {
                ExecuteTransaction();
                confirmPurches.SetActive(!confirmPurches.activeSelf);
            }
        }
        else
        {
            confirmPurches.SetActive(!confirmPurches.activeSelf);
        }


       
    }
    public void Ask(string itemName, int price)    
    {
        Text question = confirmPurches.transform.GetChild(1).GetComponent<Text>();
        if (playerData.Epas >= price)
        {
            ToggleButtons(true);
            confirmPurches.SetActive(!confirmPurches.activeSelf);
            if (buying)
            //Text for Confirm page.
            {
                question.text = "Do You Want to Purches " + itemName + " for " + price + " Epas?"; 
            }
            else
            {
                question.text = "Do You Want to Sell " + itemName + " for " + price + " Epas?";
            }
        }

        else
        {
            ToggleButtons(false);
            confirmPurches.SetActive(!confirmPurches.activeSelf);
            question.text = "You Do Not Have Enough Epas.";
        }
    }
    private void ToggleButtons(bool enoughMoney)
    {
        GameObject buttonOne = confirmPurches.transform.GetChild(0).GetChild(0).gameObject;
        GameObject buttonTwo =confirmPurches.transform.GetChild(0).GetChild(1).gameObject;
        GameObject buttonThree = confirmPurches.transform.GetChild(0).GetChild(2).gameObject;
        if(enoughMoney)
        {
            buttonOne.SetActive(true);
            buttonTwo.SetActive(true);
            buttonThree.SetActive(false);
        }
        else
        {
            buttonOne.SetActive(false);
            buttonTwo.SetActive(false);
            buttonThree.SetActive(true);
        }
    }

    //Properties
    public bool Buying { get { return buying; } set { buying = value; } }
    public Item ItemInQuestion {get { return itemInQuestion; } set { itemInQuestion = value; } }
    public PlayerData _PlayerData { get { return playerData; } set { playerData = value; } }
    public Inventory _Inventory { get { return inventory; } set { inventory = value; } }
}
