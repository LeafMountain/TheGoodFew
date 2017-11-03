using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelModel : CombatViewElement {
	
	public int Width { get; set; }
	public int Height { get; set; }
	public TileModel[,] Tiles { get; set; }
	public Vector3 Offset { get; set; }

}
