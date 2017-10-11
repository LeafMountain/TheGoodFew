using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager {
	private static BoardManager instance;

	private BoardCell[,] boardCells;
	private int mapWidth;
    private int mapHeight;

    private Grid grid;
    public AreaHelper AreaHelper{ get; private set; }

    //Need a pathfinder to find areas.

	public BoardManager(int width, int height){
		instance = this;

		mapWidth = width;
        mapHeight = height;

        CreateBoardCells();
        SetNeighbours();

        //For debugging purposes.
        // CreateGrid();
        if(AreaHelper.GetInstance() == null){
            AreaHelper = new AreaHelper();
        }
        else{
            AreaHelper = AreaHelper.GetInstance();
        }
	}

	public static BoardManager GetInstance(){
		return instance;
	}

    public BoardCell GetCell(Vector2 cell){
        return boardCells[Mathf.FloorToInt(cell.x), Mathf.FloorToInt(cell.y)];
    }

	private void CreateBoardCells(){
        boardCells = new BoardCell[mapWidth, mapHeight];
        for (int x = 0; x < mapWidth; x++){
            for (int y = 0; y < mapHeight; y++){

                //Need to check if blocked later.
                boardCells[x, y] = new BoardCell(new Vector2(x, y), BoardCell.CellType.walkable);
            }
        }

        boardCells[5, 5].ChangeType(BoardCell.CellType.blocked);
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

	public void ChangeCellType(Vector2 cell, BoardCell.CellType newType){
        if(cell.x >= 0 && cell.x < mapWidth && cell.y >= 0 && cell.y < mapHeight){
		    boardCells[Mathf.FloorToInt(cell.x), Mathf.FloorToInt(cell.y)].ChangeType(newType);
            // CreateGrid();
        }
	}

    public void CreateGrid(){
        if(grid != null){
            GameObject.Destroy(grid.gameObject);
        }
        List<GridCell> cells = new List<GridCell>();
        for (int x = 0; x < mapWidth; x++)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                if(boardCells[x, y].Type == BoardCell.CellType.blocked){
                    cells.Add(new GridCell(boardCells[x, y].Position, Grid.CellType.special));
                }
                else{
                    cells.Add(new GridCell(boardCells[x, y].Position, Grid.CellType.neutral));
                }
            }
        }
        // grid = new Grid(1, Color.red, cells);
        // grid.UpdateGrid();
    }

}