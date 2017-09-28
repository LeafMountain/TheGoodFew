//Author: Axel Stenkrona
//Description: This is the manager used in the quest hub.

using UnityEngine;

public class HubManager : MonoBehaviour {

    public ShopDataBase[] shopData;

    public GameObject subMenuGameObject;
    public SubMenuTemplate subMenuTemplete;
    
	// Use this for initialization
	void Start () {

      
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    

    public void SelectedSubHub(string shopName)
    {
        //Goes through a array of <ShopDataBase> and when the string paramenter matches the <ShopDataBase> subHubMenu 
        //string that <ShopDataBase> is used when opening the sub menu.

        for (int i = 0; i < shopData.Length; i++)
        {
            if(shopData[i].subHubName == shopName)
            {
                subMenuTemplete.ApplyShopData(shopData[i]);
            }
        }

        subMenuGameObject.SetActive(true);
    }
  
   


}
