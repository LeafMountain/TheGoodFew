public class ExperienceGain  {

    private ExperienceGain() { }
    public  ExperienceGain(int characterIndex, int experienceGained, ExperienceManager expManager)
    {
        int exp = expManager.AllCharactersExp[characterIndex];
        int level = expManager.AllCharactersLevel[characterIndex];

        exp = exp + experienceGained;

        if (exp >= 100) exp = exp - 100; level++;

        expManager.AllCharactersExp[characterIndex] = exp;
        expManager.AllCharactersLevel[characterIndex] = level;
    }

}
