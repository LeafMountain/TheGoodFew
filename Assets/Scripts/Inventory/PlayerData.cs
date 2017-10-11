//Description: This class stores the inventory of the player. Reference this whenever you need to access 
//              the amount of money the player has or the players inventory.
using UnityEngine;

public class PlayerData : MonoBehaviour {

    public PlayerDataBase dataSource;

    private Inventory inventory;
    private int epas;

    void Start()
    {
        epas = dataSource.goldCoins;
        inventory = GetComponent<Inventory>();
    }
    
    //properties

    public int Epas { get { return epas; } set { epas = value; } }
    public Inventory _Inventory { get { return inventory; } set { inventory = value; } }
}
