using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardController : CombatElement {
    private Grid grid;

	public void SetupBoard(int width, int height){
        Debug.Log("Setting up a " + width + " * " + height + " board.");
        App.Model.Board.SetMapSize(width, height);

        CreateBoardCells();
        SetNeighbours();
	}

    public TileModel GetCell(Vector2 cell){
        return App.Model.Board.Tiles[Mathf.FloorToInt(cell.x), Mathf.FloorToInt(cell.y)];
    }

	private void CreateBoardCells(){
        App.Model.Board.Tiles = new TileModel[App.Model.Board.Width, App.Model.Board.Height];
        for (int x = 0; x < App.Model.Board.Width; x++){
            for (int y = 0; y < App.Model.Board.Height; y++){

                //Need to check if blocked later.
                App.Model.Board.Tiles[x, y] = new TileModel(new Vector2(x, y), TileModel.CellType.walkable);
            }
        }

        App.Model.Board.Tiles[5, 5].ChangeType(TileModel.CellType.blocked);
    }

	private void SetNeighbours(){
		//Find and set the neightbours to the cell.
        for (int x = 0; x < App.Model.Board.Width; x++)
        {
            for (int y = 0; y < App.Model.Board.Width; y++)
            {
                TileModel[] neighbors = new TileModel[4];

                if(y < App.Model.Board.Width - 1){
                    neighbors[0] = App.Model.Board.Tiles[x, y + 1];
                }
                if(x < App.Model.Board.Width - 1 ){
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

	public void ChangeCellType(Vector2 cell, TileModel.CellType newType){
        if(cell.x >= 0 && cell.x < App.Model.Board.Width && cell.y >= 0 && cell.y < App.Model.Board.Height){
		    App.Model.Board.Tiles[Mathf.FloorToInt(cell.x), Mathf.FloorToInt(cell.y)].ChangeType(newType);
        }
	}

    public void CreateGrid(){
        if(grid != null){
            GameObject.Destroy(grid.gameObject);
        }
        List<GridCell> cells = new List<GridCell>();
        for (int x = 0; x < App.Model.Board.Width; x++)
        {
            for (int y = 0; y < App.Model.Board.Height; y++)
            {
                if(App.Model.Board.Tiles[x, y].Type == TileModel.CellType.blocked){
                    cells.Add(new GridCell(App.Model.Board.Tiles[x, y].Position, Grid.CellType.special));
                }
                else{
                    cells.Add(new GridCell(App.Model.Board.Tiles[x, y].Position, Grid.CellType.neutral));
                }
            }
        }
    }

    public TileModel[,] GetCurrenLayout(){
        return App.Model.Board.Tiles;
    }

}