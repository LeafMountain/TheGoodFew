using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatController : CombatControllerElement {

    public LevelController Level { get; private set; }

    public CombatController(CombatApplication app) : base(app) {
        Level = new LevelController(app);
    }
}
