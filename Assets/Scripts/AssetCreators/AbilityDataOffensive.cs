using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Asset creator for Offensive Abilities
[CreateAssetMenuAttribute(menuName = "Abilities/Offensive")]
public class AbilityDataOffensive : AbilityDataActive {
    public int radius;
    public bool lineOfSight;

    [HeaderAttribute("Health modifiers")]
    public int physicalDamage;
    public int magicalDamage;
    public int heal;
}
