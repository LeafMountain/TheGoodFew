using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardModel {

	public TileModel[,] Tiles { get; set; }
	public int Width { get; private set; }
    public int Height { get; private set; }

	public void SetMapSize(int width, int height){
		this.Width = width;
		this.Height = height;
	}
}
