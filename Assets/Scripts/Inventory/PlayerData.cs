using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour {

    public PlayerDataBase dataSource;

    private Inventory playerInventory;
    private int goldCoins;

    void Start()
    {
        LoadData();
    }
    public void LoadData()
    {
        playerInventory = dataSource.playerInventory;
        goldCoins = dataSource.goldCoins;
    }
    //properties

    public Inventory PlayerInventory { get { return playerInventory; } set { playerInventory = value; } }
    public int GoldCoins { get { return goldCoins; } set { goldCoins = value; } }

}
