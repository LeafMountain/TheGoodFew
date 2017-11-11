using UnityEngine;

public class LoadAbilitiesDevMode {

    private PlayerData playerData;

    private LoadAbilitiesDevMode() { }
    public LoadAbilitiesDevMode(PlayerData playerData)
    {
        this.playerData = playerData;
    }
    private void MainLoadMethod()
    {
        HeroCharacter heroCharacter = 0;

        foreach (var item in playerData.DevAbilitiesData)
        {
            int abilityIndex = 0;
            if(playerData.DevAbilitiesData[abilityIndex] != null)
            {
                playerData.CharacterAbilitiesList[abilityIndex] =
                    new EquippedAbilities();
                foreach (var ability in item.allAbilities)
                {
                    if (playerData.DevAbilitiesData[(int)heroCharacter].
                        allAbilities[abilityIndex] != null)
                    {
                        FillAbilitySlotWithDevAbility(
                            (int)heroCharacter, abilityIndex);                
                    }
                    else
                    {
                        Debug.Log("There is nothing to load from "+
                            "ability to load for ability slot " + abilityIndex+
                            ", for " + heroCharacter.ToString());
                    }
                    abilityIndex++;
                }
            }
            else
            {
                Debug.Log(
                    "There is no devAbilityData for " + 
                    heroCharacter.ToString());
            }
            heroCharacter++;
        }
    }
    private void FillAbilitySlotWithDevAbility(int hero, int abilitySlot)
    {
        playerData.CharacterAbilitiesList[hero].AllAbilities[abilitySlot] =
            playerData.DevAbilitiesData[hero].allAbilities[abilitySlot];
    }
}
