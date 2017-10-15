using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OccupantModel {

	public TileModel CurrentTile { get; private set; }
	public Vector2 Position { get { return CurrentTile.Position; } }
	
	public OccupantModel(TileModel tile){
		SetTile(tile);
	}

	public void SetTile(TileModel tile){
		CurrentTile = tile;
	}
}