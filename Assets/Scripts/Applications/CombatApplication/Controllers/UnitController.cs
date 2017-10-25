using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : CombatElement {

	public void MoveUnit(UnitModel unit, TileModel tile){
		unit.SetCurrentTile(tile);
	}

	public void DamageUnit(UnitModel unit, int damage, object damageType){
		
	}

}
