public class AbilityPointsData {

    private int[] allCharactersAP;
    private int[][] allCharactersAbilities; // int [characterIndex][AbilityIndex].
    private int[] apToUnlockAbility;
    private int[] currentlyUnlocking;

    public AbilityPointsData()
    {
        allCharactersAP = new int[6];
        allCharactersAbilities = new int[6][];
        apToUnlockAbility = new int[6];
        currentlyUnlocking = new int[6];

        for (int i = 0; i < 6; i++)
        {
            allCharactersAbilities[i] = new int[20];
        }
    }

    public int[] AllCharactersAP { get { return allCharactersAP; } set { allCharactersAP = value; } }
    public int[][] AllCharactersAbilities { get { return allCharactersAbilities; } set { allCharactersAbilities = value; } }
    public int[] ApToUnlockingAbility{get { return apToUnlockAbility; }set { apToUnlockAbility = value; }}
    public int[] CurrentlyUnlocking { get { return currentlyUnlocking; } set { currentlyUnlocking = value; } }
}
