public class ExperienceData {

    private int[] allCharactersExp;
    private int[] allCharactersLevel;

    public ExperienceData()
    {
        allCharactersExp = new int[6];
        allCharactersLevel = new int[6];
    }

    public int[] AllCharactersExp { get { return allCharactersExp; } }
    public int[] AllCharactersLevel { get { return allCharactersLevel; } }
}
