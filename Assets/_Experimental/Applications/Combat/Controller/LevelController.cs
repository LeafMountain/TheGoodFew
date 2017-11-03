using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : CombatControllerElement {

	public LevelController(CombatApplication app) : base(app){ 
		SetupBoard();
	}

	GameObject test;

	private void SetupBoard() {
		BoardView board = GameObject.FindObjectOfType(typeof(BoardView)) as BoardView;
		MeshCollider meshCollider = board.GetComponent<MeshCollider>();

		int width = Mathf.FloorToInt(meshCollider.bounds.size.x);
		int height = Mathf.FloorToInt(meshCollider.bounds.size.z);

		App.Model.Level.Width = width;
		App.Model.Level.Height = height;

		test = board.test;

		App.Model.Level.Tiles = CreateTiles(meshCollider.bounds.min, 1, width, height);
	}

	private TileModel[,] CreateTiles(Vector3 startPosition, int tileSize, int width, int height){
		TileModel[,] tiles = new TileModel[width, height];

		for (int x = 0; x < width; x++) {
			for (int y = 0; y < height; y++) {
				Vector3 worldPosition = new Vector3(startPosition.x + (x + .5f) * tileSize, startPosition.y, startPosition.z + (y  + .5f) * tileSize);

				Ray ray = new Ray(worldPosition + Vector3.up * 10, Vector3.down);

				if(Physics.Raycast(ray, Mathf.Infinity, LayerMask.NameToLayer("ground"))){
					GameObject.Instantiate(test, worldPosition, Quaternion.identity);
				}

				tiles[x, y] = new TileModel(new Vector2(x, y), (Physics.Raycast(ray, Mathf.Infinity, LayerMask.NameToLayer("ground"))) ? TileStatus.none : TileStatus.vacant);
			}
		}

		return tiles;
	}
}