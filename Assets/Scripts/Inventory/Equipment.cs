//Description: This is the class that is used during the game for holding the Equipment for each character. 
            // When a game is loaded data is feed into this class and puts the right item in each slot.
            // during development items for equipment is taken from <DevEquipment>.

using UnityEngine;

public class Equipment {

    private Item body;
    private Item mainHand;
    private Item offHand;
    private Item firstTrinket;
    private Item secondTrinket;

    private Item[] equipmentPieces;

	public Equipment () {
        
        equipmentPieces = new Item[] { body, mainHand, offHand, firstTrinket, secondTrinket };
	}

    //Properties
    public Item[] EquipmentPieces { get { return equipmentPieces; } set { equipmentPieces = value; } }	
}
