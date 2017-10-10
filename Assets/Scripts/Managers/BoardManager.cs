using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager {
	private static BoardManager instance;

	private BoardCell[,] boardCells;
	private int mapWidth;
    private int mapHeight;

	public BoardManager(int width, int height){
		instance = this;

		mapWidth = width;
        mapHeight = height;

        CreateBoardCells();
        SetNeighbours();

        CreateGrid();
	}

	public static BoardManager GetInstance(){
		return instance;
	}

	private void CreateBoardCells(){
        boardCells = new BoardCell[mapWidth, mapHeight];
        for (int x = 0; x < mapWidth; x++){
            for (int y = 0; y < mapHeight; y++){

                //Need to check if blocked later.
                boardCells[x, y] = new BoardCell(new Vector2(x, y), BoardCell.CellType.walkable);
            }
        }
    }

	private void SetNeighbours(){
		//Find and set the neightbours to the cell.
        for (int x = 0; x < mapWidth; x++)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                BoardCell[] neighbors = new BoardCell[4];

                if(y < mapHeight - 1){
                    neighbors[0] = boardCells[x, y + 1];
                }
                if(x < mapWidth - 1 ){
                    neighbors[1] = boardCells[x + 1, y];
                }
                if(y > 0){
                    neighbors[2] = boardCells[x, y - 1];
                }
                if(x > 0){
                    neighbors[3] = boardCells[x - 1, y];
                }

                boardCells[x, y].SetNeighbors(neighbors);
            }
        }
	}

	public void ChangeCellType(BoardCell cell, BoardCell.CellType newType){
		cell.ChangeType(newType);
	}

    public void CreateGrid(){
        List<GridCell> cells = new List<GridCell>();
        for (int x = 0; x < mapWidth; x++)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                cells.Add(new GridCell(boardCells[x, y].Position, Grid.CellType.neutral));
            }
        }
        Grid grid = new Grid(1, Color.red, cells);
        grid.UpdateGrid();
    }

}