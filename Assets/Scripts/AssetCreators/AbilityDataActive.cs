using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Base for active abilities
public abstract class AbilityDataActive : AbilityDataBase {
    public int cooldown = 1;

    [HeaderAttribute("Effects")]
    public AnimateObject.AnimationType startAnimation;
    public GameObject startEffect;
    public AnimateObject.AnimationType usingAnimation;
    public GameObject usingEffect;
    public GameObject endEffect;

    [Header("Sounds")]
    public AudioData startSound;
    public AudioData endSound;

    [HeaderAttribute("Space")]
    public int range;

}
