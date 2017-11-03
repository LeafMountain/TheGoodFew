public class EquippedAbilities {

    private AbilityDataOffensive abilityOne;
    private AbilityDataOffensive abilityTwo;
    private AbilityDataOffensive abilityThree;
    private AbilityDataOffensive abilityFour;
    private AbilityDataOffensive abilityFive;
    private AbilityDataOffensive abilitySix;

    private AbilityDataOffensive[] allAbilities;
    public EquippedAbilities()
    {
        allAbilities = new AbilityDataOffensive[]
            {abilityOne, abilityTwo, abilityThree, abilityFour, abilityFive, abilitySix};
    }

    public AbilityDataOffensive[] AllAbilities {
        get { return allAbilities; }
        set { allAbilities = value; } }

}
