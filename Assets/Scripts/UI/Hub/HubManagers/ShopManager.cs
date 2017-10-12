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


	void OnEnable () {
        playerData = playerDataGameObject.GetComponent<PlayerData>();
        dispayPlayerCoins.text = playerData.Epas.ToString();
        dialougeData = GetComponent<DialougeData>();
        inventory = GetComponent<Inventory>();
        GetComponentInParent<InventoryUI>().inventoryUI = subMenus.transform.Find("Inventory Display").Find("Store Inventory").gameObject;
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
    public void ExecuteTransaction()
    {
        new Transactions(this);
    }
    public void Ask(string itemName, int price)    
    {
        if (Buying)
        {
            new OpenConformation(itemName, price, this);
        }
        else
        {
            new OpenConformation(itemName, price / 2, this);
        }
    }
    public void Answer(string playerAnswer)
    {
        new PlayerAnswerOnConformation(playerAnswer, this);
    }

    //Properties
    public bool Buying { get { return buying; } set { buying = value; } }
    public Item ItemInQuestion {get { return itemInQuestion; } set { itemInQuestion = value; } }
    public PlayerData _PlayerData { get { return playerData; } set { playerData = value; } }
    public Inventory _Inventory { get { return inventory; } set { inventory = value; } }
}
