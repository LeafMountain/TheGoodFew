using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitModel {

	public UnitData Data { get; private set; }
	public TileModel CurrentTile { get; private set; }
	public TurnOrderObject TurnOrderObject { get ; private set; }

	/*
	Character Sheet;
	Current Tile;
	Health;
	Statuses;
	Abilities;
	
	*/

	public UnitModel(UnitData data, TurnOrderObject turnOrderObject, TileModel currentTile){
		Data = data;
		TurnOrderObject = turnOrderObject;
		CurrentTile = currentTile;
	}

	public void SetCurrentTile(TileModel tile){
		CurrentTile = tile;
	}
}
