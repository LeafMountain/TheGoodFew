using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitModel {

	public UnitData Data { get; private set; }
	public TileModel CurrentTile { get; private set; }

	public UnitModel(UnitData data, TileModel tile){
		Data = data;
		CurrentTile = tile;
	}
}
