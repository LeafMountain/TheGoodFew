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
        foreach (var item in playerData.DevEquipmentData)
        {
            EquipmentPart equipmentPart = 0;
            if (playerData.DevEquipmentData[(int)equipmentPart] != null)
            {

                playerData.CharacterEquipmentList[(int)heroCharacter] = 
                    new Equipment();

                foreach (var equipmentItem in item.allPieces)
                {
                    if (playerData.DevEquipmentData[(int)heroCharacter].
                        allPieces[(int)(equipmentPart)] != null)
                    {
                        FillEquipmentSlotWithDevEquipment(
                            (int)heroCharacter, (int)equipmentPart);
                    }
                    else
                    {
                        Debug.Log(
                            "There is nothing to load from the " +
                            equipmentPart.ToString() + " slot  for " + 
                            heroCharacter.ToString());
                    }
                    equipmentPart++;
                }
            }
            else
            {
                Debug.Log(
                    "There is no devEquipmentData for " + heroCharacter.ToString());
            }
            heroCharacter++;
        }
    }
    private void FillEquipmentSlotWithDevEquipment(int hero, int equipmentSlot)
{
    playerData.CharacterEquipmentList[hero].EquipmentPieces[equipmentSlot]
            = playerData.DevEquipmentData[hero].allPieces[equipmentSlot];
}


}
