using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TileStatus { none, vacant, occupied, blocked }

public class TileModel {
	public Vector2 Position { get; set; }
	public TileStatus Status { get; set; }

	public TileModel(Vector2 position, TileStatus status){
		Position = position;
		Status = status;
	}
}