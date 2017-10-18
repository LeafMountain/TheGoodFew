using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardSetupController : CombatElement {

	public void SetupBoard(int width, int height){
        App.Model.Board.SetMapSize(width, height);

        CreateBoardCells();
        SetNeighbours();
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
	
}
