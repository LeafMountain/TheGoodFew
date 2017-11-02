//Description: 

public class ExperienceManager  {

    private bool devMode;
    private DevExperienceData devExpData;
    private ExperienceData expData; //<<from a save file.
    
    private int[] allCharactersLevel;
    private int[] allCharactersExp;

    private ExperienceManager() { }
    public ExperienceManager(
        bool devMode, DevExperienceData devAllCharactersExp,
        ExperienceData experienceData) //save file should be a parameter.
    {
        this.devMode = devMode;
        devExpData = devAllCharactersExp;
        expData = experienceData;
        LoadData(devMode);

    }
    public void SaveData()
    {

    }
    private void LoadData(bool devMode)
    {
        if (devMode)
        {
            allCharactersExp = devExpData.allCharactersExp;
            allCharactersLevel = devExpData.allCharactersLevel;
        }
        else
        {
            allCharactersExp = expData.AllCharactersLevel;
            allCharactersLevel = expData.AllCharactersExp;
        }
    }
    public void GainExperience(int characterIndex, int exp)
    {
        new ExperienceGain(characterIndex, exp, this);
    }
    public void CharacterLevelUp(int characterIndex)
    {
        //Increasing the stats on a player.
    }

    //properties
    public int[] AllCharactersLevel
    { get { return allCharactersLevel; }
        set { allCharactersLevel = value; } }

    public int[] AllCharactersExp
    { get { return allCharactersExp; }
        set { allCharactersExp = value; } }

}
