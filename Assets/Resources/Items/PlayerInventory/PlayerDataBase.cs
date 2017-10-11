using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
[CreateAssetMenu(fileName = "Player Data Base")]
public class PlayerDataBase : ScriptableObject {

    public Inventory playerInventory;
    public int goldCoins;
}
