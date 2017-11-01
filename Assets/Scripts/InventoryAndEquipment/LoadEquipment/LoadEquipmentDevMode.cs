using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadEquipmentDevMode {

    private PlayerData playerData;

    public LoadEquipmentDevMode(PlayerData playerData)
    {
        this.playerData = playerData;

        MainLoadMethod();
    }

    private void MainLoadMethod()
    { 
    HeroCharacter heroCharacter = 0;
        // fortsätt här, du ska göra en metod som laddar data in till en equipment klass.
        foreach (var item in playerData.DevEquipmentData)
        {
            EquipmentPart equipmentPart = 0;
            if (playerData.DevEquipmentData[(int)equipmentPart] != null)
            {
                Debug.Log("Now loading devEquipment for " + heroCharacter.ToString());

                playerData.CharacterEquipmentList[(int)heroCharacter] = new Equipment();

                foreach (var equipmentItem in item.allPieces)
                {
                    Debug.Log("Now loading equipment item " + equipmentPart.ToString() + " for " + heroCharacter.ToString());
                    if (playerData.DevEquipmentData[(int)heroCharacter].allPieces[(int)(equipmentPart)] != null)
                    {
                        FillEquipmentSlotWithDevEquipment((int)heroCharacter, (int)equipmentPart);
                    }
                    else
                    {
                        Debug.Log("There is nothing to load from the " + equipmentPart.ToString() + " slot  for " + heroCharacter.ToString());
                    }
                    equipmentPart++;
                }
            }
            else
            {
                Debug.Log("There is no devEquipmentData for " + heroCharacter.ToString());
            }
            heroCharacter++;
        }
            
        
    }
    private void FillEquipmentSlotWithDevEquipment(int hero, int equipmentSlot)
{
    playerData.CharacterEquipmentList[hero].EquipmentPieces[equipmentSlot] = playerData.DevEquipmentData[hero].allPieces[equipmentSlot];
}


}
