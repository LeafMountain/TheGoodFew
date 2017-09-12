using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Asset creator and data holder for UnitData
[CreateAssetMenuAttribute(menuName = "Unit")]
public class UnitData : ScriptableObject {
    public enum UnitType { hostile, friendly, neutral }
    public enum Class { Soldier, Scout, Archer, Acolyte, Apprentice }

    public string title;
    public Sprite portrait;
    public UnitType type;
    public Class primaryClass;
    // public Class.Type secondaryClass;

    [HeaderAttribute("Base Level")]
    public int soldierLevel;
    public int scoutLevel;
    public int archerLevel;
    public int acolyteLevel;
    public int apprenticeLevel;

    [HeaderAttribute("Base Stats")]
    [RangeAttribute(10, 20)]
    [SerializeField]
    private float health = 10;
    [RangeAttribute(10, 20)]
    [SerializeField]
    private float atk = 10;
    [RangeAttribute(10, 20)]
    [SerializeField]
    private float def = 10;
    [RangeAttribute(10, 20)]
    [SerializeField]
    private float pow = 10;
    [RangeAttribute(10, 20)]
    [SerializeField]
    private float res = 10;
    [RangeAttribute(10, 20)]
    [SerializeField]
    private float speed = 10;
    [RangeAttribute(1, 10)]
    [SerializeField]
    private float movement = 6;
    private float hit = 1;
    private float mHit = 1;
    private float block = 0;

    public int Health { get { return Mathf.FloorToInt(health); } }
    public int Atk { get { return Mathf.FloorToInt(atk); } }
    public int Def { get { return Mathf.FloorToInt(def); } }
    public int Pow { get { return Mathf.FloorToInt(pow); } }
    public int Res { get { return Mathf.FloorToInt(res); } }
    public int Speed { get { return Mathf.FloorToInt(speed); } }
    public int Movement { get { return Mathf.FloorToInt(movement); } }

    public int Hit { get { return (int)(hit * 100); } }
    public int MHit { get { return (int)(mHit * 100); } }
    public int Block { get { return (int)(block * 100); } }


    [HeaderAttribute("Base Abilities")]
    public AbilityDataPassive passiveAbility;
    public AbilityDataActive weaponAbility;
    public AbilityDataActive activeAbility1;
    public AbilityDataActive activeAbility2;
    public AbilityDataActive activeAbility3;
    public AbilityDataActive activeAbility4;
    public AbilityDataActive activeAbility5;

    public AbilityDataActive[] storedAbilities;

    public List<Ability> CreateAbilities () {
        List<Ability> abilities = new List<Ability>();

        if (weaponAbility)
            abilities.Add(new Ability(weaponAbility));
        if (activeAbility1)
            abilities.Add(new Ability(activeAbility1));
        if (activeAbility2)
            abilities.Add(new Ability(activeAbility2));
        if (activeAbility3)
            abilities.Add(new Ability(activeAbility3));
        if (activeAbility4)
            abilities.Add(new Ability(activeAbility4));
        if (activeAbility5)
            abilities.Add(new Ability(activeAbility5));

        return abilities;
    }
}