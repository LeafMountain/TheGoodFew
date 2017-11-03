using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : CombatControllerElement {

	public LevelController(CombatApplication app) : base(app){ 
		SetupBoard();
		SetOccupants();
	}

	GameObject test;

	private void SetupBoard() {
		BoardView board = GameObject.FindObjectOfType(typeof(BoardView)) as BoardView;
		MeshCollider meshCollider = board.GetComponent<MeshCollider>();

		int width = Mathf.FloorToInt(meshCollider.bounds.size.x);
		int height = Mathf.FloorToInt(meshCollider.bounds.size.z);

		App.Model.Level.Width = width;
		App.Model.Level.Height = height;

		//Debug. Remove later
		test = board.test;
		//Debug. Remove later

		Vector3 offset = meshCollider.bounds.min;
		App.Model.Level.Offset = offset;

		App.Model.Level.Tiles = CreateTiles(offset, 1, width, height);
	}

	private TileModel[,] CreateTiles(Vector3 offset, int tileSize, int width, int height){
		TileModel[,] tiles = new TileModel[width, height];

		for (int x = 0; x < width; x++) {
			for (int y = 0; y < height; y++) {
				Vector3 worldPosition = new Vector3(offset.x + (x + .5f) * tileSize, offset.y, offset.z + (y  + .5f) * tileSize);

				Ray ray = new Ray(worldPosition + Vector3.up * 10, Vector3.down);

				tiles[x, y] = new TileModel(new Vector2(x, y), (Physics.Raycast(ray, Mathf.Infinity, LayerMask.NameToLayer("ground"))) ? TileStatus.none : TileStatus.vacant);
			}
		}

		return tiles;
	}

	private void SetOccupants(){
		GridOccupant[] occupants = GameObject.FindObjectsOfType(typeof(GridOccupant)) as GridOccupant[];

		for (int i = 0; i < occupants.Length; i++) {
			Vector2 boardPosition = ConvertToBoardPosition(occupants[i].transform.position);
			Vector3 occupantPos = ConvertToWorldPosition(boardPosition);
			Debug.Log(boardPosition);

			App.Model.Level.Tiles[Mathf.FloorToInt(boardPosition.x), Mathf.FloorToInt(boardPosition.y)].Status = TileStatus.occupied;

			GameObject.Instantiate(test, occupantPos, Quaternion.identity);
		}
	}

	public Vector2 ConvertToBoardPosition(Vector3 worldPosition){
		return new Vector2(Mathf.Floor(worldPosition.x - App.Model.Level.Offset.x), Mathf.Floor(worldPosition.z - App.Model.Level.Offset.z));
	}

	public Vector3 ConvertToWorldPosition(Vector2 boardPosition){
		return new Vector3(boardPosition.x + App.Model.Level.Offset.x + .5f, 0, boardPosition.y + App.Model.Level.Offset.z + .5f);
	}
}