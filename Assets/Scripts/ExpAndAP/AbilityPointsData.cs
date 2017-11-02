public class AbilityPointsData {

    private int[] allCharactersAP;
    private DevAbilityPointsData.AllCharactersAbilities[] allCharactersAbilities; // int [characterIndex][AbilityIndex].
    private int[] apToUnlockAbility;
    private int[] currentlyUnlocking;

    public AbilityPointsData()
    {
        allCharactersAP = new int[6];
        allCharactersAbilities = new DevAbilityPointsData.AllCharactersAbilities[6];
            
        apToUnlockAbility = new int[6];
        currentlyUnlocking = new int[6];

    }

    public int[] AllCharactersAP {
        get { return allCharactersAP; }
        set { allCharactersAP = value; } }
    public DevAbilityPointsData.AllCharactersAbilities[] AllCharactersAbilities {
        get { return allCharactersAbilities; }
        set { allCharactersAbilities = value; } }
    public int[] ApToUnlockingAbility{
        get { return apToUnlockAbility; }
        set { apToUnlockAbility = value; }}
    public int[] CurrentlyUnlocking {
        get { return currentlyUnlocking; }
        set { currentlyUnlocking = value; } }
}
