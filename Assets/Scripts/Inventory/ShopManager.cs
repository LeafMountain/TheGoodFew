using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour {

    
    private PlayerData playerData;
    public GameObject playerDataGameObject;
    public DisplayItemInformation informationDisplay;



    //GameObjects
    public GameObject confirmPurches;

    public int shopGoldCoins;
    public Text dispayPlayerCoins;

    private bool buying; //<< Is the player in the sell or buy menu. Set when player press buy or sell button.
    private Item itemInQuestion; //<<The item that is being sold or bought. Set when player presses a itemslot.
	
	void Start () {
        playerData = playerDataGameObject.GetComponent<PlayerData>();
        dispayPlayerCoins.text = playerData.GoldCoins.ToString();
    }

    public void OpenShopSection()
    {
        if(buying)
        {
            new OpenBuyingSection();
        }
        else
        {
            new OpenSellingSection();
        }
    }

    private void BuyItem(Item item)
    {
        

    }
    private void SellItem(Item item)
    {

    }
    public void Answer(string answer)
    {
        if (answer == "Yes")
        {
            if(buying)
            {
                BuyItem(itemInQuestion);
                confirmPurches.SetActive(!confirmPurches.activeSelf);
            }
            else
            {
                SellItem(itemInQuestion);
                confirmPurches.SetActive(!confirmPurches.activeSelf);
            }
        }
        else
        {
            confirmPurches.SetActive(!confirmPurches.activeSelf);
        }


       
    }
    public void Ask(string itemName, int price, bool buying)
    {
        Text question = confirmPurches.transform.GetChild(1).GetComponent<Text>();
        if (playerData.GoldCoins >= price)
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
    public bool Buying { set { buying = value; } }
    public Item ItemInQuestion { set { itemInQuestion = value; } }

}
