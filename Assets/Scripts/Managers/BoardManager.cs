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

	private void SetNeighbours(BoardCell cell){
		//Find and set the neightbours to the cell.
	}

	public void ChangeCellType(BoardCell cell, BoardCell.CellType newType){
		cell.ChangeType(newType);
	}

}


public class BoardCell {
    public enum CellType { error, walkable, blocked }
    
    public Vector2 Position { get; private set; }   
    public CellType Type { get; private set; }
    public int MoveCost { get; private set; }
	public BoardCell[] neighbours = new BoardCell[4];

    public BoardCell(Vector2 position, CellType type){
        Position = position;
        Type = type;
    }

    public void SetMoveCost(int moveCost){
        MoveCost = moveCost;
    }

	public void ChangeType(CellType type){
		Type = type;
	}
}
