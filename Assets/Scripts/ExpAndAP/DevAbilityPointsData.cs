using System;
using UnityEngine;

[SerializeField]

[CreateAssetMenu(fileName = "new AbilityPointsArray", menuName = "DevData/AbilityPointArray")]
public class DevAbilityPointsData : ScriptableObject {

    [Serializable]
    public struct AllCharactersAbilities
    {
        public int[] abilities;
    }

    public int[] allCharactersAP;
    
    public AllCharactersAbilities[] allCharactersAbilities; // int [characterIndex][AbilityIndex] value: 0 or 1, locked or unlocked.
    public int[] currentlyUnlocking; //what ability is the character unlocking [characterIndex] value: 0 - 200.	
}

