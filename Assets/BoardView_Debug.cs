using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardView_Debug : CombatElement {

	public int width = 10;
	public int height = 10;
	public GameObject tile;

	private Image[,] images;


	void Start () {
		images = new Image[width, height];

		for (int x = 0; x < width; x++)
		{
			for (int y = 0; y < height; y++)
			{
				GameObject _tile = Instantiate(tile, transform);
				images[x, y] = _tile.GetComponent<Image>();
			}
		}

		App.Controller.BoardController.SetupBoard(width, height);

		AddObstacles();
		AddUnits();
		PaintBoard();
		Pathfind(App.Controller.TurnController.GetCurrentUnit());		
	}

	private void AddObstacles(){
		for (int x = 0; x < width; x++){
			for (int y = 0; y < height; y++){
				if(Random.Range(0,100) < 20){
					App.Controller.BoardController.ChangeCellType(new Vector2(x, y), TileModel.CellType.blocked);
				}
			}
		}		
	}

	private void AddUnits(){
		List<Vector2> positions = new List<Vector2>();
		positions.Add(new Vector2(2, 2));
		positions.Add(new Vector2(2, 3));
		positions.Add(new Vector2(2, 4));
		positions.Add(new Vector2(2, 5));
		
		positions.Add(new Vector2(8, 2));
		positions.Add(new Vector2(8, 3));
		positions.Add(new Vector2(8, 4));
		positions.Add(new Vector2(8, 5));

		for (int i = 0; i < positions.Count; i++)
		{
			TileModel tile = App.Controller.BoardController.GetCell(positions[i]);			
			UnitModel unit = new UnitModel(null, tile);
			tile.SetUnit(unit);
			App.Controller.TurnController.AddUnit(unit);
			tile.ChangeType(TileModel.CellType.blocked);
		}
	}

	private void PaintBoard(){
		TileModel[,] tiles = App.Controller.BoardController.GetCurrenLayout();
		for (int x = 0; x < width; x++){
			for (int y = 0; y < height; y++){
				if(tiles[x, y].Unit != null){
					images[x, y].color = Color.blue;
				}
				else if(tiles[x, y].Type == TileModel.CellType.blocked){
					images[x, y].color = Color.black;
				}
				else{
					images[x, y].color = Color.white;
				}
			}
		}
	}

	private void Pathfind(UnitModel unit){
		List<TileModel> tiles = App.Controller.PathfindingController.GetArea2(unit.CurrentTile, 6);

		for (int i = 0; i < tiles.Count; i++)
		{
			if(tiles[i] != unit.CurrentTile){
				this.images[(int)tiles[i].Position.x, (int)tiles[i].Position.y].color = Color.green;
			}
			else{
				this.images[(int)tiles[i].Position.x, (int)tiles[i].Position.y].color = Color.magenta;				
			}
		}
	}
}
