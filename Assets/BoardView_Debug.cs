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
		// width = App.Model.Board.Width;
		// height = App.Model.Board.Height;

		GetComponent<GridLayoutGroup>().constraintCount = width;
		CreateTiles();

		App.Controller.Board.Setup.SetupBoard(width, height);

		AddObstacles();
		AddUnits();
		PaintBoard();
		Pathfind(App.Controller.TurnController.GetCurrentUnit());
	}

	private void CreateTiles(){
		images = new Image[width, height];

		for (int x = 0; x < width; x++)
		{
			for (int y = height - 1; y >= 0; y--)
			{
				GameObject _tile = Instantiate(tile, transform);
				images[x, y] = _tile.GetComponent<Image>();
			}
		}
	}

	private void AddObstacles(){
		for (int x = 0; x < width; x++){
			for (int y = 0; y < height; y++){
				if(Random.Range(0,100) < 20){
					App.Controller.Board.ChangeCellType(new Vector2(x, y), TileModel.CellType.blocked);
				}
			}
		}		
	}

	private void AddUnits(){
		List<Vector2> positions = new List<Vector2>();
		positions.Add(new Vector2(width / 2, height / 2));
		positions.Add(new Vector2(width - 1, height - 1));
		
		// positions.Add(new Vector2(2, 3));
		// positions.Add(new Vector2(2, 4));
		// positions.Add(new Vector2(2, 5));
		
		// positions.Add(new Vector2(8, 2));
		// positions.Add(new Vector2(8, 3));
		// positions.Add(new Vector2(8, 4));
		// positions.Add(new Vector2(8, 5));

		for (int i = 0; i < positions.Count; i++)
		{
			TileModel tile = App.Controller.Board.GetCell(positions[i]);			
			UnitModel unit = new UnitModel(null, tile);
			tile.SetUnit(unit);
			App.Controller.TurnController.AddUnit(unit);
			tile.ChangeType(TileModel.CellType.blocked);
		}
	}

	private void PaintBoard(){
		TileModel[,] tiles = App.Controller.Board.GetCurrenLayout();
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

	private List<TileModel> tiles;
	private UnitModel unit;

	private void Pathfind(UnitModel unit){
		// tiles = App.Controller.PathfindingController.GetArea2(unit.CurrentTile, 6);
		tiles = App.Controller.pathfindingController1.GetWalkableTiles(unit.CurrentTile, 6);
		this.unit = unit;
		StartCoroutine("Fade");
		// this.images[(int)unit.CurrentTile.Position.x, (int)unit.CurrentTile.Position.y + 1].color = Color.green;

		// for (int i = 0; i < tiles.Count; i++)
		// {
		// 	if(tiles[i] != unit.CurrentTile){
		// 		this.images[(int)tiles[i].Position.x, (int)tiles[i].Position.y].color = Color.green;
		// 	}
		// 	else{
		// 		this.images[(int)tiles[i].Position.x, (int)tiles[i].Position.y].color = Color.magenta;				
		// 	}
		// }
	}

	IEnumerator Fade() {

		for (int i = 0; i < tiles.Count; i++)
		{
			if(tiles[i] != unit.CurrentTile){
				this.images[(int)tiles[i].Position.x, (int)tiles[i].Position.y].color = Color.green;
			}
			else{
				this.images[(int)tiles[i].Position.x, (int)tiles[i].Position.y].color = Color.magenta;				
			}
			yield return new WaitForSeconds(.01f);			
		}
	}
}
