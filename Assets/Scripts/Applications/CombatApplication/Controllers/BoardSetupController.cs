using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardSetupController : CombatElement {

    private void Awake(){
        SetupBoard(App.View.BoardView.GetWidth(), App.View.BoardView.GetHeight());
    }

	private void SetupBoard(int width, int height){
        App.Model.Board.SetMapSize(width, height);

        CreateBoardCells();
        SetNeighbours();
	}

    private void Start(){
        FindObstacles();
    }

	private void CreateBoardCells(){
        for (int x = 0; x < App.Model.Board.Width; x++){
            for (int y = 0; y < App.Model.Board.Height; y++){

                //Need to check if blocked later.
                App.Model.Board.Tiles[x, y] = new TileModel(new Vector2(x, y), TileModel.CellType.walkable);
            }
        }
    }

	private void SetNeighbours(){
		//Find and set the neightbours to the cell.
        for (int x = 0; x < App.Model.Board.Width; x++)
        {
            for (int y = 0; y < App.Model.Board.Height; y++)
            {
                TileModel[] neighbors = new TileModel[4];

                if(y < App.Model.Board.Height - 1){
                    neighbors[0] = App.Model.Board.Tiles[x, y + 1];
                }
                if(x < App.Model.Board.Width - 1){
                    neighbors[1] = App.Model.Board.Tiles[x + 1, y];
                }
                if(y > 0){
                    neighbors[2] = App.Model.Board.Tiles[x, y - 1];
                }
                if(x > 0){
                    neighbors[3] = App.Model.Board.Tiles[x - 1, y];
                }

                App.Model.Board.Tiles[x, y].SetNeighbors(neighbors);
            }
        }
	}

    private void FindObstacles() {
		GridOccupant[] occupants = (GridOccupant[])GameObject.FindObjectsOfType(typeof(GridOccupant));

		for (int i = 0; i < occupants.Length; i++){
			// App.Model.TurnModel.AddUnit(new UnitModel(null, occupants[i], App.Controller.Board.GetCell(new Vector2(occupants[i].transform.position.x, occupants[i].transform.position.z))));

            for (int j = 0; j < occupants[i].Positions().Count; j++) {
                TileModel tile = App.Controller.Board.GetCell(new Vector2(occupants[i].Positions()[j].x, (occupants[i].Positions()[j].z)));
                tile.ChangeType(TileModel.CellType.blocked);
                Debug.Log(App.Model.Board.Tiles.Length);
            }
		}
	}
	
}
