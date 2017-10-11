//Author: Axel Stenkrona
//Description: This is the manager used in the quest hub.

using UnityEngine;

public class HubManager : MonoBehaviour {

    public GameObject[] subMenuGameObject;
    
    public void SelectedSubHub(string objectName)
    {
        //Goes through a array of <ShopDataBase> and when the string paramenter matches the <ShopDataBase> subHubMenu 
        //string that <ShopDataBase> is used when opening the sub menu.

        for (int i = 0; i < subMenuGameObject.Length; i++)
        {
            if(subMenuGameObject[i].name == objectName + "Menu")
            {
                subMenuGameObject[i].SetActive(true);
                break;
            }
        }
    }
}
