using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardCell {
    public enum CellType { error, walkable, blocked }
    
    public Vector2 Position { get; private set; }   
    public CellType Type { get; private set; }
    public int MoveCost { get; private set; }
	public BoardCell[] neighbors = new BoardCell[4];
    public GridOccupant Occupant { get; private set; }

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

    public void SetNeighbors(BoardCell[] neighbors){
        this.neighbors = neighbors;
    }

    public void SetOccupant(GridOccupant occupant){
        Occupant = occupant;
    }
}
