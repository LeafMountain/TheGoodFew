using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileModel {
    public enum CellType { error, walkable, blocked }
    
    public Vector2 Position { get; private set; }   
    public CellType Type { get; private set; }
    public int MoveCost { get; private set; }
	public TileModel[] neighbors;
    public UnitModel Unit { get; private set; }

    public TileModel(Vector2 position, CellType type){
        Position = position;
        Type = type;

        SetMoveCost(1);
    }

    public void SetMoveCost(int moveCost){
        MoveCost = moveCost;
    }

	public void ChangeType(CellType type){
		Type = type;
	}

    public void SetNeighbors(TileModel[] neighbors){
        this.neighbors = neighbors;
    }

    public void SetUnit(UnitModel unit){
        Unit = unit;
    }

    public void RemoveOccupant(){
        Unit = null;
    }
}
