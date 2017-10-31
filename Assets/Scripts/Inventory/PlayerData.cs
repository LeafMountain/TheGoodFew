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

    private AbilityPointsManager apManager;
    private ExperienceManager expManager;

    public DevAbilityPointsData devAPData;
    public DevExperienceData devExpData;

    private AbilityPointsData apData;
    private ExperienceData expData;
    
    public bool devMode;

    void Start()
    {
        epas = dataSource.goldCoins;
        inventory = GetComponent<Inventory>();
        characterEquipmentList = new Equipment[6];
        if (devEquipmentData == null) devEquipmentData = new DevEquipment[6];

        apData = new AbilityPointsData();
        //need a method to load the abilityPointsData from a xml file.
        expData = new ExperienceData();
        //need a method to load experienceData from a xml file.

        new LoadEquipmentData(devMode, this);
        apManager = new AbilityPointsManager(devMode, devAPData, apData);
        expManager = new ExperienceManager(devMode, devExpData, expData);

        Debug.Log("PlayerDataBase Start() is DONE");
    }


    
    //properties

    public int Epas { get { return epas; } set { epas = value; } }
    public Inventory _Inventory { get { return inventory; } set { inventory = value; } }
    public DevEquipment[] DevEquipmentData { get { return devEquipmentData; } set { devEquipmentData = value; } }
    public Equipment[] CharacterEquipmentList { get { return characterEquipmentList; } set { characterEquipmentList = value;} }
    public AbilityPointsManager ApManager { get { return apManager; } }
    public ExperienceManager ExpManager { get { return expManager; } }
}
