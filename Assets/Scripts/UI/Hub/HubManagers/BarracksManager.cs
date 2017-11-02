using UnityEngine;

public class BarracksManager : MonoBehaviour {

    private GameObject iconFrame;
    private GameObject inventoryDisplay;
    private InventoryUI inventoryUI;
    private EquipmentManager equipmentManager;
    private Item itemInQuestion;
    

    private bool waitForSlotPicked;

    public DisplayItemInformation informationDisplay;
    public Inventory playerInventory;
    public Sprite[] characterIcon; //< Might be changed to 3D models instead.
    public GameObject playerEquipment;
    public PlayerData playerData; 
    public GameObject levelPanel;
    public GameObject expBar;
    public GameObject apBar;

    void Start()
    {
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

    public void InventorySlotClicked(GameObject go, Item item)
    {
        itemInQuestion = item;
        equipmentManager.InventorySlotClicked(go);
        _InventoryUI.UpdateUI();
        equipmentManager.UpdateEqpmtUI();
    }

    
    public void OpenCharacterEquipmentMenu(int index)
    {
        new OpenCharacter(this, index);
    }
        

    //Properties
    public GameObject IconFrame {
        get { return iconFrame; } set { iconFrame = value; } }
    public GameObject InventoryDisplay {
        get { return inventoryDisplay; } }
    public InventoryUI _InventoryUI {
        get { return inventoryUI; } set { inventoryUI = value; } }
    public Item ItemInQuestion {
        get { return itemInQuestion; } set { itemInQuestion = value; } }
    public EquipmentManager _EquipmentManager {
        get { return equipmentManager; } set { equipmentManager = value; } }
    public bool WaitForSlotPicked {
        get { return waitForSlotPicked; } set { waitForSlotPicked = value; } }
}
