//Author: Axel Stenkrona
//Description: Component attached to the sub menu templete <GameObject> in the quest hub scene.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubMenuTemplate : MonoBehaviour {

    private ShopDataBase shopData;

   
   

	// Use this for initialization
	void Start () {
       
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadShopInventory(ShopDataBase shopData)
    {
        //Puts the <ShopDataBase> info into the menu templete

        this.shopData = shopData;

        if (shopData != null)
        {
           

        }
        else {Debug.Log("Shop Data is Missing!!!!");}
    }

    

}
