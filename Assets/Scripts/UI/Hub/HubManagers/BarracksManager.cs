using UnityEngine;

public class BarracksManager : MonoBehaviour {

    private GameObject iconFrame;
    private GameObject inventoryDisplay;
    private InventoryUI inventoryUI;
    private EquipmentManager equipmentManager;
    private Item itemInQuestion;
    private AbilityDataOffensive abilityInQuestion;
    private int characterIndex;

    private bool displayingEquipment;

    private bool waitForSlotPicked;

    public DisplayItemInformation informationDisplay;
    public Inventory playerInventory;
    public Sprite[] characterIcon; //< Might be changed to 3D models instead.
    public GameObject playerEquipment;
    public GameObject playerAbilities;
    public PlayerData playerData; 
    public GameObject playerInformation;
    public GameObject toggleButton;


    void Start()
    {
        displayingEquipment = true;
        equipmentManager = new EquipmentManager(this);
    }
    
    void OnEnable()
    {
        iconFrame = 
            transform.Find("SubMenus").Find("IconFrame").gameObject;
        inventoryDisplay = 
            transform.Find("SubMenus").Find("Inventory Display").gameObject;

        inventoryUI = GetComponentInParent<InventoryUI>();
        inventoryUI.Inventory = playerInventory;
        inventoryUI.inventoryUI = 
            inventoryDisplay.transform.GetChild(0).gameObject;
        inventoryUI.UpdateUI();
    }

    public void SlotClicked(
        GameObject go, Item item, AbilityDataOffensive ability)
    {
        if (item != null)
        {
            itemInQuestion = item;
            equipmentManager.SlotClicked(go);
        }
        else
        {
            equipmentManager.SlotClicked(go);
        }
        new UpdateUI(
            _EquipmentManager, true, true, true);
    }

    
    public void OpenCharacterEquipmentMenu(int index)
    {
        new OpenCharacter(this, index);
        characterIndex = index;
    }
    public void ToggleInventory()
    {
        displayingEquipment = !displayingEquipment;
        new ToggleEquipmentAndAbilities(this);
    }

    //Properties
    public GameObject IconFrame {
        get { return iconFrame; }
        set { iconFrame = value; } }
    public GameObject InventoryDisplay {
        get { return inventoryDisplay; } }
    public InventoryUI _InventoryUI {
        get { return inventoryUI; }
        set { inventoryUI = value; } }
    public Item ItemInQuestion {
        get { return itemInQuestion; }
        set { itemInQuestion = value; } }
    public EquipmentManager _EquipmentManager {
        get { return equipmentManager; }
        set { equipmentManager = value; } }
    public bool WaitForSlotPicked {
        get { return waitForSlotPicked; }
        set { waitForSlotPicked = value; } }
    public bool DisplayingEquipment {
        get { return displayingEquipment; } }
    public Inventory Inventory { get { return playerInventory; } }
    public int CharacterIndex { get { return characterIndex; } }
    public AbilityDataOffensive AbilityInQuestion {
        get { return abilityInQuestion; }
        set { abilityInQuestion = value; } }
    
}
