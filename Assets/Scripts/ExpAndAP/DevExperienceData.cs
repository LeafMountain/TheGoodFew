using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenuAttribute(fileName = "new ExperienceArray", menuName = "DevData/ExperienceArray")]
public class DevExperienceData : ScriptableObject {

    public int[] allCharactersExp;
    public int[] allCharactersLevel;
}
