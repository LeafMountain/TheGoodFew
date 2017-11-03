using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatModel {

    public LevelModel Level { get; private set; }

    public CombatModel(){
        Level = new LevelModel();
    }
}
