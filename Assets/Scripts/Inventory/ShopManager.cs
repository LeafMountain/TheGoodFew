using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour {

    public Inventory shopInventory;
    public PlayerData playerData;

    //GameObjects
    public GameObject confirmPurches;

    public int shopGoldCoins;

	
	void Start () {
		
	}
	
	
	void Update () {
		
	}

    public void BuyItem(Item item)
    {
        

    }
    public void SellItem(Item item)
    {

    }
    private void Answer(string answer, bool buying, Item item)
    {
        if (answer == "Yes")
        {
            if(buying)
            {
                BuyItem(item);
            }
            else
            {
                SellItem(item);
            }
        }

       
    }
    public void Ask()
    {
        confirmPurches.SetActive(!confirmPurches.activeSelf);
    }
}
