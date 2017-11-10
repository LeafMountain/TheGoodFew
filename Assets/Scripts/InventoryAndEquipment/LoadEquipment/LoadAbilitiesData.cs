public class LoadAbilitiesData {

    private bool devMode;
    private PlayerData playerData;

    private LoadAbilitiesData() { }
    public LoadAbilitiesData(bool devMode, PlayerData playerData)
    {
        this.devMode = devMode;
        this.playerData = playerData;

        if (devMode)
        {
            LoadDeveloperAbilities();
        }
        else
        {
            LoadSaveFileAbilities();
        }

    }
    private void LoadDeveloperAbilities()
    {
        new LoadAbilitiesDevMode(playerData);
    }
    private void LoadSaveFileAbilities()
    {

    }
}
