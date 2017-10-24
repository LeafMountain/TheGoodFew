//Description: This class stores the inventory of the player. Reference this whenever you need to access 
//              the amount of money the player has or the players inventory.
using UnityEngine;

public enum HeroCharacter { Alena, Gramps, Jaques, Milo, Olivia, Wilburr}

public class PlayerData : MonoBehaviour {

    public PlayerDataBase dataSource;

    private Equipment[] characterEquipmentList;
    private Inventory inventory;
    private int epas;
    public DevEquipment[] devEquipmentData;
    
    public bool devMode;

    void Start()
    {
        epas = dataSource.goldCoins;
        inventory = GetComponent<Inventory>();
        characterEquipmentList = new Equipment[6];
        if (devEquipmentData == null) devEquipmentData = new DevEquipment[6];
        new LoadEquipmentData(devMode, this);
    }


    
    //properties

    public int Epas { get { return epas; } set { epas = value; } }
    public Inventory _Inventory { get { return inventory; } set { inventory = value; } }
    public DevEquipment[] DevEquipmentData { get { return devEquipmentData; } set { devEquipmentData = value; } }
    public Equipment[] CharacterEquipmentList { get { return characterEquipmentList; } set { characterEquipmentList = value;} }
    
}
