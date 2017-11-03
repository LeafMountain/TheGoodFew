//Description: 

public enum AbilityIndex { AssultPush, Blessing, Bullseye, DirtyTrick,
                            Doubleshot,LightArmor, MissleOfMagic, Recover,
                            Shieldblock, Slow, ThrowDagger}
public class AbilityPointsManager  {

    private bool devMode;
    private DevAbilityPointsData devAPData;
    private AbilityPointsData apData; 

    private int[] allCharactersAP;
    private DevAbilityPointsData.AllCharactersAbilities[] allCharactersAbilities; // int [characterIndex][AbilityIndex].
    private int[] currentlyUnlocking; // [abilityIndex]


    private AbilityPointsManager() { }
    public AbilityPointsManager(
        bool devMode, DevAbilityPointsData devAPData, 
        AbilityPointsData apData) //save file should be a parameter.
    {
        this.devMode = devMode;
        this.devAPData = devAPData;
        this.apData = apData;
        LoadData(devMode);
    }
    public void SaveData()
    {

    }
    private void LoadData(bool devMode)
    {
        if(devMode)
        {
            allCharactersAP = devAPData.allCharactersAP;
            allCharactersAbilities = devAPData.allCharactersAbilities;
            currentlyUnlocking = devAPData.currentlyUnlocking;

        }
        else
        {
            allCharactersAP = apData.AllCharactersAP;
            allCharactersAbilities = apData.AllCharactersAbilities;
            currentlyUnlocking = apData.CurrentlyUnlocking;
        }
    }
    private void GainAbilityPoints(int characterIndex, int experienceGained)
    {
       
    }
    public void CharacterUnlockAbility(int characterIndex, AbilityIndex unLockedAbility)
    {
        //Increasing the stats on a player.
    }


    public int[] AllCharactersAP {
        get { return allCharactersAP; }
        set { allCharactersAP = value; } }
    public DevAbilityPointsData.AllCharactersAbilities[] 
        AllCharactersAbilities {
        get { return allCharactersAbilities; }
        set { allCharactersAbilities = value; } }
    public int[] CurrentlyUnlocking {
        get { return currentlyUnlocking; }
        set { currentlyUnlocking = value; }}
    public AbilityPointsData APData {
        get { return apData; }
        set { apData = value; } }
}
