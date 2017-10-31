using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "new AbilityPointsArray", menuName = "DevData/AbilityPointArray")]
public class DevAbilityPointsData : ScriptableObject {

    public int[] allCharactersAP;
    [SerializeField]
    public int[][] allCharactersAbilities; // int [characterIndex][AbilityIndex] value: 0 or 1, locked or unlocked.
    public int[] apToUnlockAbilities;
    public int[] currentlyUnlocking; //what ability is the character unlocking [characterIndex] value: 0 - 200.	
}

