//Author: Axel Stenkrona
//Description: Component attached to the sub menu templete <GameObject> in the quest hub scene.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubMenuTemplate : MonoBehaviour {

    private ShopDataBase shopData;

    public Image shopKeeperPortrait;
    public Image backGrondSprite;

    public Text dialobueBox;

    private AudioClip backGroundAudioTrack;

    //private List<Item> shopItems //<- the items the shop is selling.
    //private List<Item> playerItems //<- list of the items the player has.
   

	// Use this for initialization
	void Start () {
       
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ApplyShopData(ShopDataBase shopData)
    {
        //Puts the <ShopDataBase> info into the menu templete

        this.shopData = shopData;

        if (shopData != null)
        {
            //if (shopData.characterPortraits != null) { shopKeeperPortrait.sprite = shopData.characterPortraits[0]; } else { Debug.Log("Character Portraits are Missing!"); }
            if (shopData.backGroundSprite != null) { backGrondSprite.sprite = shopData.backGroundSprite; } else { Debug.Log("Back Ground Sprite is Missing!"); }
            

        }
        else {Debug.Log("Shop Data is Missing!!!!");}
    }

    

}
