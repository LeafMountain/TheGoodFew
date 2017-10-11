using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour {

    public PlayerDataBase dataSource;

    private int goldCoins;

    void Start()
    {
        LoadData();
    }
    public void LoadData()
    {
        goldCoins = dataSource.goldCoins;
    }
    //properties

    public int GoldCoins { get { return goldCoins; } set { goldCoins = value; } }

}
