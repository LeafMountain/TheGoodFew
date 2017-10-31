public class AbilityPointsData {

    private int[] allCharactersAP;
    private int[][] allCharactersAbilities; // int [characterIndex][AbilityIndex].
    private int[] apToUnlockAbility;
    private int[] currentlyUnlocking;

    public int[] AllCharactersAP { get { return allCharactersAP; } set { allCharactersAP = value; } }
    public int[][] AllCharactersAbilities { get { return allCharactersAbilities; } set { allCharactersAbilities = value; } }
    public int[] ApToUnlockingAbility{get { return apToUnlockAbility; }set { apToUnlockAbility = value; }}
    public int[] CurrentlyUnlocking { get { return currentlyUnlocking; } set { currentlyUnlocking = value; } }
}
