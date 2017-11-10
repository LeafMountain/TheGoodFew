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
                //Continue here, compare LoadEquipmentDevMode.cs
            }
        }
    }
}
