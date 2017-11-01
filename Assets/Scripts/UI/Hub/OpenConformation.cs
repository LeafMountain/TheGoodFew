//Type: Controller
using UnityEngine;
using UnityEngine.UI;

public class OpenConformation {

    private string itemName;
    private int price;
    private ShopManager shopManager;

    private OpenConformation () { }
    public OpenConformation(
        string itemName, int price, ShopManager shopManager)
    {
        this.itemName = itemName;
        this.price = price;
        this.shopManager = shopManager;
        Ask();
    }

    public void Ask()
    {
        shopManager.confirmPurches.SetActive(
            !shopManager.confirmPurches.activeSelf);
        Text question = 
            shopManager.confirmPurches.
            transform.GetChild(1).GetComponent<Text>();

        if (shopManager.Buying)
        {
            ToggleButtons(true);
            if (shopManager._PlayerData.Epas >= price)
            //Text for Confirm page.
            {
                question.text = 
                    "Do You Want to Purches " 
                    + itemName + " for " + price + " Epas?";
            }
            else
            {
                ToggleButtons(false);
                question.text = "You Do Not Have Enough Epas.";
            }
        }
         else
        {
            ToggleButtons(true);
            question.text = 
                "Do You Want to Sell " + 
                itemName + " for " + price + " Epas?";
        }
    }
    private void ToggleButtons(bool enoughMoney)
    {
        Transform mamaTransform = shopManager.confirmPurches.transform;

        GameObject buttonOne = 
            mamaTransform.GetChild(0).GetChild(0).gameObject;
        GameObject buttonTwo = 
            mamaTransform.GetChild(0).GetChild(1).gameObject;
        GameObject buttonThree = 
            mamaTransform.GetChild(0).GetChild(2).gameObject;

        if (enoughMoney)
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

}
