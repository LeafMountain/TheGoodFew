//Description: Depending on the player selling or buying epas are 
// removed or added, and items are moved from player or shop inventory.
public class Transactions  {

    private ShopManager shopManager;
    private Item itemInQuestion;
    private bool buying;


    private Transactions() { }
    public Transactions(ShopManager shopManager)
    {
        this.shopManager = shopManager;
        itemInQuestion = shopManager.ItemInQuestion;
        buying = shopManager.Buying;

        NewEpaAmount(shopManager._PlayerData.Epas);
        MoveItem();
        shopManager.dispayPlayerCoins.text = 
            shopManager._PlayerData.Epas.ToString();

    }
    private void NewEpaAmount(int currentAmount)
    {
        int temp = currentAmount;
        // Epas are either removed or added.
        if (buying)
        {
            temp  = temp - itemInQuestion.price; 
        }
        else
        {
            //selling an item gives the player 50% of the 
            //original price or worth of the item.
            temp = temp + (itemInQuestion.price / 2); 
        }

        shopManager._PlayerData.Epas = temp;
    }
    private void MoveItem()
    {
        if(buying)
        {
            shopManager._Inventory.Remove(itemInQuestion);
            shopManager._PlayerData._Inventory.Add(itemInQuestion);
        }
        else
        {
            shopManager._PlayerData._Inventory.Remove(itemInQuestion);
            shopManager._Inventory.Add(itemInQuestion);
        }

        shopManager.storeUI.UpdateUI();
    }

}
